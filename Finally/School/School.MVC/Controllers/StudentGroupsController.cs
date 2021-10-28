using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Services.Base;
using School.BLL.Services.Course;
using School.BLL.Services.StudentGroup;
using School.BLL.Services.StudentRequest;
using School.BLL.Services.Teacher;
using School.Core.Models;
using School.Core.Models.Pages;
using School.Core.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    [Authorize(Roles = "admin, manager, student")]
    public class StudentGroupsController : Controller
    {
        private readonly IStudentGroupService _groupService;
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        private readonly IStudentRequestService _requestService;

        private readonly IEntityService<Lesson> _lessonsService;

        private readonly IMapper _mapper;

        public StudentGroupsController(IStudentGroupService groupService,
           ITeacherService teacherService,
           ICourseService courseService,
           IStudentRequestService requestService,
           IMapper mapper,
           IEntityService<Lesson> lessonsService)
        {
            _groupService = groupService;
            _teacherService = teacherService;
            _courseService = courseService;
            _requestService = requestService;

            _lessonsService = lessonsService;
            _mapper = mapper;
        }

        #region Index - get first 10 groups
        public async Task<IActionResult> Index(PaginationOptions options)
        {
            try
            {
                var groups = await _groupService.GetByPages(options);
                return View(groups);
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion

        #region Delete group
        [Authorize(Roles = "admin, manager")]
        [HttpGet]
        public async Task<IActionResult> Delete(StudentGroupModel groupModel)
        {
            try
            {
                var groups = _mapper.Map<Group>(groupModel);
                await _groupService.Delete(groups.Id);

                return RedirectToAction(nameof(Index));
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion

        #region Edit group
        [Authorize(Roles = "admin, manager")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id, int? courseId)
        {
            StudentGroupModel model;
            if (id.HasValue)
            {
                var group = await _groupService.GetById(id.Value);
                model = _mapper.Map<StudentGroupModel>(group);
                model.Students = _mapper.Map<IEnumerable<StudentModel>>(group.Students);

                var lessons = await _lessonsService.GetAll();
                
                ViewBag.Lessons = _mapper.Map<IEnumerable<LessonModel>>(lessons.Where(x => x.GroupId == group.Id).ToList());
            }
            else
            {
                model = new StudentGroupModel
                {
                    StartDate = DateTime.Today
                };
            }

            ViewBag.Teachers = _mapper.Map<IEnumerable<TeacherModel>>(await _teacherService.GetAll());
            ViewBag.Courses = _mapper.Map<IEnumerable<CourseModel>>(await _courseService.GetAll());
            ViewBag.IsAdmin = HttpContext.User.IsInRole("admin");

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Edit(StudentGroupModel groupModel)
        {
            try
            {
                if(groupModel.LessonId == 0)
                {
                    for (int i = groupModel.Lessons.Count() - 1; i > -1; i--)
                    {
                        if (groupModel.Lessons[i].IsActive == false)
                        {
                            groupModel.Lessons.Remove(groupModel.Lessons[i]);
                            //_lessonsService.GetById(groupModel.Lessons[i].Gr)
                        }
                    }
                }

                if (groupModel.LessonId > 0)
                {
                    //foreach (var item in groupModel.Lessons)
                    //{
                    //    item = 
                    //}
                    var lessons = await _lessonsService.GetById(groupModel.LessonId);

                    groupModel.Lessons.Add(_mapper.Map<LessonModel>(lessons));
                }

                var group = _mapper.Map<Group>(groupModel);
                if (groupModel.Id > 0)
                    await _groupService.Update(group);
                else
                    await _groupService.Create(group);

                return RedirectToAction(nameof(Index));
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion

        #region Error Action
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}