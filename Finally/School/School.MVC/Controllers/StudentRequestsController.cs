﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Services.Course;
using School.BLL.Services.Student;
using School.BLL.Services.StudentGroup;
using School.BLL.Services.StudentRequest;
using School.Core.Models;
using School.Core.Models.Enum;
using School.Core.Models.Pages;
using School.Core.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    [Authorize(Roles = "admin, student")]
    public class StudentRequestsController : Controller
    {
        private readonly IStudentRequestService _requestService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IStudentGroupService _studentGroupService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public StudentRequestsController(IMapper mapper,
            IStudentService studentService,
            ICourseService courseService,
            IStudentRequestService requestService,
            UserManager<IdentityUser> userManager,
            IStudentGroupService studentGroupService)
        {
            _mapper = mapper;
            _studentService = studentService;
            _courseService = courseService;
            _requestService = requestService;
            _userManager = userManager;
            _studentGroupService = studentGroupService;
        }
        public async Task<Student> GetCurrentStudentBySystemUser()
        {
            IdentityUser currentSystemUser = await _userManager.GetUserAsync(User);

            var getAllStudents = await _studentService.GetAll();

            Student getCurrentStudentBySystemUserId = getAllStudents.FirstOrDefault(student => student.UserId == currentSystemUser.Id);
            return getCurrentStudentBySystemUserId;
        }

        #region Вывод списка заявок (для каждого пользователя своя логика)
        public async Task<IActionResult> Index(bool? includeClosed, PaginationOptions options)
        {
            if (User.IsInRole("student"))
            {
                var allRequests = includeClosed == true ? await _requestService.GetAll() : await _requestService.GetAllOpen();

                var student = await GetCurrentStudentBySystemUser();

                var selectRequestsCurrentStudent = allRequests.Where(studentReq => studentReq.StudentId == student.Id).ToList();
                if (selectRequestsCurrentStudent == null)
                {

                }
                return View(_mapper.Map<IEnumerable<StudentRequestModel>>(selectRequestsCurrentStudent));
            }

            else if (User.IsInRole("admin"))
            {
                var students = await _requestService.GetByPages(options);

                var requests = includeClosed == true ? await _requestService.GetAll() : await _requestService.GetAllOpen();

                return View(_mapper.Map<IEnumerable<StudentRequestModel>>(requests));
            }

            else
            {
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion

        #region Принять заявку
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AcceptRequest(int? id)
        {
            var model = id.HasValue ? _mapper.Map<StudentRequestModel>(await _requestService.GetById(id.Value)) : new StudentRequestModel() { Created = DateTime.Today };
            var allGroups = (await _studentGroupService.GetAll());
            var filteredGroups = allGroups.Where(g => g.Status == GroupStatus.NotStarted && g.CourseId == model.CourseId);

            ViewBag.Groups = _mapper.Map<IEnumerable<StudentGroupModel>>(filteredGroups);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AcceptRequest(StudentRequestModel model)
        {

            if (!ModelState.IsValid) return View(model);

            var student = await _studentService.GetById(model.StudentId);
            student.GroupId = model.GroupId;
            await _studentService.Update(student);

            var request = _mapper.Map<StudentRequest>(model);
            request.Status = School.Core.Models.Enum.RequestStatus.Closed;
            await _requestService.Update(request);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Изменить заявку
        [HttpGet]
        [Authorize(Roles = "admin, student")]
        public async Task<IActionResult> Edit(int? id)
        {
            var model = id.HasValue ? _mapper.Map<StudentRequestModel>(await _requestService.GetById(id.Value)) : new StudentRequestModel() { Created = DateTime.Today };
            IdentityUser currentSystemUser = await _userManager.GetUserAsync(User);

            if (currentSystemUser.UserName == "student")
            {
                if (id.HasValue && model != null)
                {
                    var student = await GetCurrentStudentBySystemUser();
                    if (model.StudentId == student.Id && student != null)
                    {
                        return View(model);
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }

            var allCourses = await _courseService.GetAll();
            ViewBag.Courses = _mapper.Map<IEnumerable<CourseModel>>(allCourses.OrderBy(c => c.Title));

            var allStudents = await _studentService.GetAll();
            ViewBag.Students = _mapper.Map<IEnumerable<StudentModel>>(allStudents.OrderBy(s => s.LastName));

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, student")]
        public async Task<IActionResult> Edit(StudentRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var student = await GetCurrentStudentBySystemUser();
            model.StudentId = student.Id;
            var request = _mapper.Map<StudentRequest>(model);

            if (model.Id > 0)
                await _requestService.Update(request);
            else
                await _requestService.Create(request);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Удалить заявку
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _requestService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Exception-view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}