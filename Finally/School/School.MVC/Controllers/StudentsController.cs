using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Services.Student;
using School.BLL.Services.StudentGroup;
using School.Core.Models;
using School.Core.Models.Pages;
using School.Core.ShortModels;
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
        private readonly UserManager<IdentityUser> _userManager;

        public StudentsController(IStudentService studentService, IStudentGroupService groupService, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _studentsService = studentService;
            _groupService = groupService;
            _mapper = mapper;
            _userManager = userManager;
        }

        #region Index - get first 10 student
        public async Task<IActionResult> Index(PaginationOptions options)
        {
            try
            {               
                var students = await _studentsService.GetByPages(options);

                return View(students);
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion

        #region Edit student
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
                    {
                        IdentityUser user = new();

                        user.UserName = student.Email;
                        user.Email = student.Email;
                        user.EmailConfirmed = true;

                        student.UserId = user.Id;

                        IdentityResult result = _userManager.CreateAsync(user, studentModel.Password).Result;

                        if (result.Succeeded)
                        {
                            _userManager.AddToRoleAsync(user, "student").Wait();
                            await _studentsService.Create(student);
                        }
                    }

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
        #endregion

        #region Delete student
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
        #endregion 

        #region Search student
        public async Task<IActionResult> Search(string search, PaginationOptions options)
        {
            var students = await _studentsService.Search(search);
            return View(nameof(Index), new PageList<Student>(students.AsQueryable(), options));
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