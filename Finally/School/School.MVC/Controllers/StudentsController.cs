using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Models;
using School.BLL.Models.Enum;
using School.BLL.Services.Student;
using School.BLL.Services.StudentGroup;
using School.BLL.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index(string sortRecords, string searchString, int skip, int take, EnumPageActions action, EnumSearchParametersStudent searchParameter)
        {
            try
            {
                ViewData["searchString"] = searchString;
                ViewData["searchParameter"] = searchParameter;


                var students = await _studentsService.DisplayingIndex(action, searchString, (EnumSearchParameters)(int)searchParameter, take, skip);

                return View(_mapper.Map<IEnumerable<StudentModel>>(students));
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
                var model = id.HasValue
                   ? _mapper.Map<StudentModel>(await _studentsService.GetById(id.Value))
                   : new StudentModel();

                ViewBag.Groups = _mapper.Map<IEnumerable<StudentGroupModel>>(await _groupService.GetAll());
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
        public async Task<IActionResult> Edit(StudentModel studentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = _mapper.Map<Student>(studentModel);
                    if (studentModel.Id > 0)
                        await _studentsService.Update(student);
                    else
                        await _studentsService.Create(student);

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
        public async Task<IActionResult> Delete(StudentModel studentModel)
        {
            try
            {
                var student = _mapper.Map<Student>(studentModel);
                await _studentsService.Delete(student.Id);

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