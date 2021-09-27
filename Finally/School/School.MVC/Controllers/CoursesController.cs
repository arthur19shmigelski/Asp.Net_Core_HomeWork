using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using School.BLL.Models;
using School.BLL.Services.Course;
using School.BLL.Services.StudentGroup;
using School.BLL.Services.StudentRequest;
using School.BLL.Services.Topic;
using School.BLL.ShortModels;
using School.MVC.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AcademyCRM.MVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ITopicService _topicService;
        private readonly IStudentGroupService _groupService;
        private readonly IStudentRequestService _requestService;
        private readonly IConfiguration _configuration;
        private readonly SecurityOptions _securityOptions;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService courseService,
            IMapper mapper,
            ITopicService topicService,
            IStudentRequestService requestService,
            IConfiguration configuration,
            IOptions<SecurityOptions> options,
            IStudentGroupService groupService
            )
        {
            _mapper = mapper;
            _topicService = topicService;
            _requestService = requestService;
            _configuration = configuration;
            _securityOptions = options.Value;
            _courseService = courseService;
            _groupService = groupService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var courses = await _courseService.GetAll();
                var models = _mapper.Map<IEnumerable<CourseModel>>(courses);

                foreach (var model in models)
                {
                    var value = await _requestService.GetOpenRequestsCountByCourse(model.Id);
                    model.RequestsCount = value;
                }

                return View(models);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var model = id.HasValue ? _mapper.Map<CourseModel>(await _courseService.GetById(id.Value)) : new CourseModel();

                if (id.HasValue)
                    model.Requests = _mapper.Map<IEnumerable<StudentRequestModel>>(await _requestService.GetOpenRequestsByCourse(id.Value));

                ViewBag.Topics = _mapper.Map<IEnumerable<TopicModel>>(await _topicService.GetAll());
                return View(model);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseModel courseModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(courseModel);

                //Плохо мапируется... Почему?
                var course = _mapper.Map<Course>(courseModel);

                var topicForCourse = await _topicService.GetById(courseModel.TopicId);

                course.Topic = topicForCourse;

                if (courseModel.Id > 0)
                    await _courseService.Update(course);
                else
                    await _courseService.Create(course);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                await _courseService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}