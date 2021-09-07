using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Models;
using School.BLL.Services.Base;
using School.BLL.Services.StudentRequest;
using School.BLL.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AcademyCRM.MVC.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class StudentRequestsController : Controller
    {
        private readonly IStudentRequestService _requestService;
        private readonly IEntityService<Course> _courseService;
        private readonly IEntityService<Student> _studentService;
        private readonly IMapper _mapper;

        public StudentRequestsController(IMapper mapper,
            IEntityService<Student> studentService,
            IEntityService<Course> courseService,
            IStudentRequestService requestService)
        {
            _mapper = mapper;
            _studentService = studentService;
            _courseService = courseService;
            _requestService = requestService;
        }

        public IActionResult Index(bool? includeClosed)
        {
            try
            {
                var requests = includeClosed == true ? _requestService.GetAll() : _requestService.GetAllOpen();
                return View(_mapper.Map<IEnumerable<StudentRequestModel>>(requests));
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
                var model = id.HasValue ? _mapper.Map<StudentRequestModel>(_requestService.GetById(id.Value)) : new StudentRequestModel() { Created = DateTime.Today };
                ViewBag.Courses = _mapper.Map<IEnumerable<CourseModel>>(_courseService.GetAll().OrderBy(c => c.Title));
                ViewBag.Students = _mapper.Map<IEnumerable<StudentModel>>(_studentService.GetAll().OrderBy(s => s.LastName));
                return View(model);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public IActionResult Edit(StudentRequestModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var request = _mapper.Map<StudentRequest>(model);
                if (model.Id > 0)
                    _requestService.Update(request);
                else
                    _requestService.Create(request);
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