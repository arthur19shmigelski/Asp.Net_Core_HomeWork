using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Models;
using School.BLL.Services.Course;
using School.BLL.Services.StudentGroup;
using School.BLL.Services.StudentRequest;
using School.BLL.Services.Teacher;
using School.MVC.Models;
using System;
using System.Collections.Generic;

namespace School.MVC.Controllers
{
    [Authorize(Roles = "admin, manager, student")]
    public class StudentGroupsController : Controller
    {
        private readonly IStudentGroupService _groupService;
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        private readonly IStudentRequestService _requestService;
        private readonly IMapper _mapper;

        public StudentGroupsController(IStudentGroupService groupService, ITeacherService teacherService, ICourseService courseService, IStudentRequestService requestService, IMapper mapper)
        {
            _groupService = groupService;
            _teacherService = teacherService;
            _courseService = courseService;
            _requestService = requestService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var groups = _groupService.GetAll();
            return View(_mapper.Map<IEnumerable<StudentGroupModel>>(groups));
        }

        [HttpGet]
        public IActionResult Edit(int? id, int? courseId)
        {
            StudentGroupModel model;
            if (id.HasValue)
            {
                var group = _groupService.GetById(id.Value);
                model = _mapper.Map<StudentGroupModel>(group);
                model.Students =_mapper.Map<IEnumerable<StudentModel>>(group.Students);
            }
            else
            {
                
                model = new StudentGroupModel
                {
                    CourseId = courseId,
                    Students = _mapper.Map<IEnumerable<StudentModel>>(
                        _requestService.GetStudentsByCourse(courseId.Value))
                };
            }
            
            ViewBag.Teachers = _mapper.Map<IEnumerable<TeacherModel>>(_teacherService.GetAll());
            ViewBag.Courses = _mapper.Map<IEnumerable<CourseModel>>(_courseService.GetAll());
            ViewBag.IsAdmin = HttpContext.User.IsInRole("admin");

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(StudentGroupModel groupModel)
        {
            if (!ModelState.IsValid) return View(groupModel);

            var group = _mapper.Map<StudentGroup>(groupModel);
            if (groupModel.Id > 0)
                _groupService.Update(group);
            else
                _groupService.Create(group);

            return RedirectToAction("Index");
        }
    }
}