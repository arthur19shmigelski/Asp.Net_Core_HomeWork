using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Models;
using School.BLL.Services.Teacher;
using School.BLL.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var teachers = await _teacherService.GetAll();
                return View(_mapper.Map<IEnumerable<TeacherModel>>(teachers));
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
                var modelTeacher = id.HasValue
            ? _mapper.Map<TeacherModel>(await _teacherService.GetById(id.Value))
            : new TeacherModel();
                return View(_mapper.Map<TeacherModel>(modelTeacher));
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeacherModel teacherModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var teacher = _mapper.Map<Teacher>(teacherModel);
                    if (teacherModel.Id > 0)
                        await _teacherService.Update(teacher);
                    else
                        await _teacherService.Create(teacher);

                    return RedirectToAction("Index");
                }
                return View(teacherModel);
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(TeacherModel teacherModel)
        {
            try
            {
                var teacher = _mapper.Map<Teacher>(teacherModel);
                await _teacherService.Delete(teacher.Id);

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