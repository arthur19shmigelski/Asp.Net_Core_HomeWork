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

        public LessonsController(IEntityService<Lesson> lessonsService, IMapper mapper, IStudentGroupService groupService, ITopicService topicService)
        {
            _lessonsService = lessonsService;
            _mapper = mapper;
            _groupService = groupService;
            _topicService = topicService;
        }
        public async Task<IActionResult> Start()
        {
            var topics = await _topicService.GetAll();
            var models = _mapper.Map<IEnumerable<TopicModel>>(topics);
                
            return View(models);
        }
        public async Task<IActionResult> Index(string title)
        {
            var lessons = _mapper.Map<IEnumerable<LessonModel>>(await _lessonsService.GetAll());
            var model = lessons.Where(l => l.TopicLesson == title).ToList();

            ViewBag.Topic = title;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        #region Edit course
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            var model = id.HasValue ? _mapper.Map<LessonModel>(await _lessonsService.GetById(id.Value)) : new LessonModel();


            ViewBag.Group = _mapper.Map<IEnumerable<StudentGroupModel>>(await _groupService.GetAll());
            return View(model);
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
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion

        public ActionResult Delete(int id)
        {
            return View();
        }

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
