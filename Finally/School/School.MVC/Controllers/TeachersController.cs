using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Models;
using School.BLL.Services.Base;
using School.BLL.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace School.MVC.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class TeachersController : Controller
    {
        private readonly IEntityService<Teacher> _teacherService;
        private readonly IMapper _mapper;

        public TeachersController(IEntityService<Teacher> teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            try
            {
                var teachers = _teacherService.GetAll();
                return View(_mapper.Map<IEnumerable<TeacherModel>>(teachers));
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
                var modelTeacher = id.HasValue
            ? _mapper.Map<TeacherModel>(_teacherService.GetById(id.Value))
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
        public IActionResult Edit(TeacherModel teacherModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var teacher = _mapper.Map<Teacher>(teacherModel);
                    if (teacherModel.Id > 0)
                        _teacherService.Update(teacher);
                    else
                        _teacherService.Create(teacher);

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
        public IActionResult Delete(TeacherModel teacherModel)
        {
            try
            {
                var teacher = _mapper.Map<Teacher>(teacherModel);
                _teacherService.Delete(teacher);

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