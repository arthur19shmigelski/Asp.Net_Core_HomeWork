using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Models;
using School.BLL.Services.Course;
using School.BLL.Services.Student;
using School.BLL.Services.StudentRequest;
using School.BLL.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyCRM.MVC.Controllers
{
    [Authorize(Roles = "admin, manager, student")]
    public class StudentRequestsController : Controller
    {
        private readonly IStudentRequestService _requestService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentRequestsController(IMapper mapper,
            IStudentService studentService,
            ICourseService courseService,
            IStudentRequestService requestService)
        {
            _mapper = mapper;
            _studentService = studentService;
            _courseService = courseService;
            _requestService = requestService;
        }

        public async Task<IActionResult> Index(bool? includeClosed)
        {
            try
            {
                var requests = includeClosed == true ? await _requestService.GetAll() : await _requestService.GetAllOpen();
                return View(_mapper.Map<IEnumerable<StudentRequestModel>>(requests));
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
                var model = id.HasValue ? _mapper.Map<StudentRequestModel>(await _requestService.GetById(id.Value)) : new StudentRequestModel() { Created = DateTime.Today };

                var allCourses = await _courseService.GetAll();
                ViewBag.Courses = _mapper.Map<IEnumerable<CourseModel>>(allCourses.OrderBy(c => c.Title));

                var allStudents = await _studentService.GetAll();
                ViewBag.Students = _mapper.Map<IEnumerable<StudentModel>>(allStudents.OrderBy(s => s.LastName));

                return View(model);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentRequestModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var request = _mapper.Map<StudentRequest>(model);
                if (model.Id > 0)
                    await _requestService.Update(request);
                else
                    await _requestService.Create(request);
                return RedirectToAction(nameof(Index));
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