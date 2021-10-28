using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using School.BLL.Services.Course;
using School.BLL.Services.StudentGroup;
using School.BLL.Services.StudentRequest;
using School.BLL.Services.Topic;
using School.Core.Models;
using School.Core.Models.Filters;
using School.Core.Models.Pages;
using School.Core.ShortModels;
using School.MVC.Configuration;
using School.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    [TypeFilter(typeof(LocalExceptionFilter), Order = int.MinValue)]
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
        #region Index - get first 10 courses
        public async Task<IActionResult> Index(PaginationOptions options)
        {
            try
            {
                var courses = await _courseService.GetByPages(options);
                foreach (var course in courses)
                {
                    var value = await _requestService.GetOpenRequestsCountByCourse(course.Id);
                    course.RequestsCount = value;
                }

                return View(courses);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion

        #region Edit course
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            var model = id.HasValue ? _mapper.Map<CourseModel>(await _courseService.GetById(id.Value)) : new CourseModel();

            if (id.HasValue)
                model.Requests = _mapper.Map<IEnumerable<StudentRequestModel>>(await _requestService.GetOpenRequestsByCourse(id.Value));

            ViewBag.Topics = _mapper.Map<IEnumerable<TopicModel>>(await _topicService.GetAll());
            return View(model);
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
        #endregion

        #region Delete course
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
        #endregion

        #region Search course
        public async Task<IActionResult> Search(string search, PaginationOptions options)
        {
            var courses = await _courseService.Search(search);
            
            return View(nameof(Index), new PageList<Course>(courses.AsQueryable(), options));
        }
        #endregion

        #region Filter расширенный поиск
        [HttpGet]
        public IActionResult Filter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Filter(CourseFilterModel model, PaginationOptions options)
        {
            var courses = await _courseService.Filter(_mapper.Map<CourseFilter>(model));

            return View(nameof(Index), new PageList<Course>(courses.AsQueryable(), options));
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