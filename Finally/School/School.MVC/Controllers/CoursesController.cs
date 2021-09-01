using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using School.BLL.Models;
using School.BLL.Services.Base;
using School.BLL.Services.StudentRequest;
using School.MVC.Configuration;
using School.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AcademyCRM.MVC.Controllers
{
    [Authorize(Roles = "admin, manager, student")]
    public class CoursesController : Controller
    {
        private readonly IEntityService<Course> _courseService;
        private readonly IEntityService<Topic> _topicService;
        private readonly IStudentRequestService _requestService;
        private readonly IConfiguration _configuration;
        private readonly SecurityOptions _securityOptions;
        private readonly IMapper _mapper;

        public CoursesController(IEntityService<Course> courseService,
            IMapper mapper,
            IEntityService<Topic> topicService,
            IStudentRequestService requestService,
            IConfiguration configuration,
            IOptions<SecurityOptions> options
            )
        {
            _mapper = mapper;
            _topicService = topicService;
            _requestService = requestService;
            _configuration = configuration;
            _securityOptions = options.Value;
            _courseService = courseService;

        }

        public IActionResult Index()
        {
            try
            {
                var courses = _courseService.GetAll();
                var models = _mapper.Map<IEnumerable<CourseModel>>(courses);

                foreach (var model in models)
                {
                    model.RequestsCount = _requestService.GetOpenRequestsCountByCourse(model.Id);
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
        public IActionResult Edit(int? id)
        {
            try
            {
                var model = id.HasValue ? _mapper.Map<CourseModel>(_courseService.GetById(id.Value)) : new CourseModel();

                if (id.HasValue)
                    model.Requests = _mapper.Map<IEnumerable<StudentRequestModel>>(_requestService.GetOpenRequestsByCourse(id.Value));

                ViewBag.Topics = _mapper.Map<IEnumerable<TopicModel>>(_topicService.GetAll());
                return View(model);
            }


            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public IActionResult Edit(CourseModel courseModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(courseModel);

                var course = _mapper.Map<Course>(courseModel);
                if (courseModel.Id > 0)
                    _courseService.Update(course);
                else
                    _courseService.Create(course);
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
