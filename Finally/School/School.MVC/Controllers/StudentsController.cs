using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Models;
using School.BLL.Services.Base;
using School.MVC.Models;
using System.Collections.Generic;

namespace School.MVC.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class StudentsController : Controller
    {
        private readonly IEntityService<Student> _studentsService;
        private readonly IEntityService<StudentGroup> _groupService;
        private readonly IMapper _mapper;

        public StudentsController(IEntityService<Student> studentService, IEntityService<StudentGroup> groupService, IMapper mapper, IEntityService<Student> studentServiceEntity)
        {
            _studentsService = studentService;
            _groupService = groupService;
            _mapper = mapper;
            _studentsService = studentServiceEntity;
        }

        public IActionResult Index()
        {
            var students = _studentsService.GetAll();
            //var students = _studentsService.GetAll();
            return View(_mapper.Map<IEnumerable<StudentModel>>(students));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = id.HasValue
                ? _mapper.Map<StudentModel>(_studentsService.GetById(id.Value))
                : new StudentModel();

            ViewBag.Groups = _mapper.Map<IEnumerable<StudentGroupModel>>(_groupService.GetAll());
            ViewBag.Type = model.Type;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StudentModel studentModel)
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

        [HttpGet]
        public IActionResult Delete(StudentModel studentModel)
        {
            var student = _mapper.Map<Student>(studentModel);
            _studentsService.Delete(student);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
