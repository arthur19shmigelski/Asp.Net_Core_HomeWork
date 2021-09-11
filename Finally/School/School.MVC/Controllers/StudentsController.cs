using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Models;
using School.BLL.Services.Student;
using School.BLL.Services.StudentGroup;
using School.BLL.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace School.MVC.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentsService;
        private readonly IStudentGroupService _groupService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IStudentGroupService groupService, IMapper mapper)
        {
            _studentsService = studentService;
            _groupService = groupService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            try
            {
                var students = _studentsService.GetAll();
                return View(_mapper.Map<IEnumerable<StudentModel>>(students));
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
                var model = id.HasValue
                   ? _mapper.Map<StudentModel>(_studentsService.GetById(id.Value))
                   : new StudentModel();

                ViewBag.Groups = _mapper.Map<IEnumerable<StudentGroupModel>>(_groupService.GetAll());
                ViewBag.Type = model.Type;
                return View(model);
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public IActionResult Edit(StudentModel studentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = _mapper.Map<Student>(studentModel);
                    if (studentModel.Id > 0)
                        _studentsService.Update(student);
                    else
                        _studentsService.Create(student);

                    return RedirectToAction("Index");
                }
                return View(studentModel);
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public IActionResult Delete(StudentModel studentModel)
        {
            try
            {
                var student = _mapper.Map<Student>(studentModel);
                _studentsService.Delete(student.Id);

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