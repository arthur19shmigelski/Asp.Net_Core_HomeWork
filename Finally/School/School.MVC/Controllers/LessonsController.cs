using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Services.Base;
using School.BLL.Services.Course;
using School.BLL.Services.StudentGroup;
using School.BLL.Services.Topic;
using School.Core.Models;
using School.Core.ShortModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    public class LessonsController : Controller
    {
        private readonly IEntityService<Lesson> _lessonsService;
        private readonly IMapper _mapper;
        private readonly IStudentGroupService _groupService;
        private readonly ITopicService _topicService;
        private readonly ICourseService _courseService;

        public LessonsController(IEntityService<Lesson> lessonsService, IMapper mapper, IStudentGroupService groupService, ITopicService topicService, ICourseService courseService)
        {
            _lessonsService = lessonsService;
            _mapper = mapper;
            _groupService = groupService;
            _topicService = topicService;
            _courseService = courseService;
        }
        public async Task<IActionResult> Start()
        {
            var modelGroups = _mapper.Map<IEnumerable<StudentGroupModel>>(await _groupService.GetAll());

            return View(modelGroups);
        }
        public async Task<IActionResult> Index(string title)
        {
            var modelLessons = _mapper.Map<IEnumerable<LessonModel>>(await _lessonsService.GetAll());

            var groups = await _groupService.GetAll();

            var group = groups.Where(x => x.Title == title).FirstOrDefault();

            var selectModelLessonsByTitle = modelLessons.Where(l => l.GroupId == group.Id).ToList();

            ViewBag.Topic = title;
            return View(selectModelLessonsByTitle);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        #region Edit course
        [HttpGet]
        public async Task<IActionResult> Edit(int? id, string titleGroup)
        {
            LessonModel modelLesson = null;
            if (id.HasValue)
            {
                modelLesson = _mapper.Map<LessonModel>(await _lessonsService.GetById(id.Value));
                
                ViewBag.NameGroup = modelLesson.Group.Title;
                return View(modelLesson);
            }
            else
            {
                modelLesson = new LessonModel();
                var modelGroups = _mapper.Map<IEnumerable<StudentGroupModel>>(await _groupService.GetAll());

                var currentGroup = modelGroups.Where(x => x.Title == titleGroup).FirstOrDefault();
                modelLesson.GroupId = currentGroup.Id;

                ViewBag.NameGroup = currentGroup.Title;
                return View(modelLesson);
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LessonModel lessonModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(lessonModel);

                var lesson = _mapper.Map<Lesson>(lessonModel);

                if (lesson.Id > 0)
                    await _lessonsService.Update(lesson);
                else
                    await _lessonsService.Create(lesson);
                return RedirectToAction("Start");
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion

        #region Delete student
        [HttpGet]
        public async Task<IActionResult> Delete(LessonModel lessonModel)
        {
            try
            {
                var lesson = _mapper.Map<Lesson>(lessonModel);
                await _lessonsService.Delete(lesson.Id);

                return RedirectToAction(nameof(Start));
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
