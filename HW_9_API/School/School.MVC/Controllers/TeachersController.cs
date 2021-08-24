using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Models;
using School.BLL.Services.Teacher;
using School.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var teachers = _teacherService.GetAll();
            return View(_mapper.Map<IEnumerable<TeacherModel>>(teachers));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var modelTeacher = id.HasValue
                ? _mapper.Map<TeacherModel>(_teacherService.GetById(id.Value))
                : new TeacherModel();
            return View(_mapper.Map<TeacherModel>(modelTeacher));
        }

        [HttpPost]
        public IActionResult Edit(TeacherModel teacherModel)
        {
            if(ModelState.IsValid)
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

        [HttpGet]
        public IActionResult Delete(TeacherModel teacherModel)
        {
            var teacher = _mapper.Map<Teacher>(teacherModel);
            _teacherService.Delete(teacher);

            return RedirectToAction(nameof(Index));
        }
    }
}
