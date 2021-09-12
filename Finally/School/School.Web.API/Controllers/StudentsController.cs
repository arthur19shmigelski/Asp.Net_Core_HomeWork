﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Models;
using School.BLL.Services.Base;
using School.BLL.Services.Student;
using School.BLL.Services.StudentGroup;
using School.BLL.ShortModels;
using School.Web.API.Dto;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace School.Web.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            var allStudents = _studentsService.GetAll();
            var mapingStudent = _mapper.Map<IEnumerable<StudentDto>>(allStudents);

            return  Ok(mapingStudent);

            //Вариант 2. Вывод в список (выглядит лучше, чем обычно...)
            //var allStudents = _studentsService.GetAll();
            //var mappingToStudentModel = _mapper.Map<IEnumerable<StudentModel>>(allStudents);

            //List<string> shotList = new List<string>();

            //foreach (var item in mappingToStudentModel)
            //{
            //    shotList.Add($"{item.FullName} - {item.BirthDate} - {item.Email}".ToString());
            //}
            //return  Ok(shotList);
        }

        // GET api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            Student student = _studentsService.GetById(id);
            if (student == null)
                return NotFound();
            else
            {
                var mapingStudent = _mapper.Map<StudentDto>(student);
                return new ObjectResult(mapingStudent);
            }
        }


        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Student>> Post(StudentDto student)
        {
            if(student != null)
            {
                var newStudent = _mapper.Map<Student>(student);
                _studentsService.Create(newStudent);
                return new ObjectResult(newStudent);
            }
            else
                return BadRequest();
        }

        // PUT api/users/
        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, "Студент создан")]
        public async Task<ActionResult<Student>> Put(StudentDto student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            else
            {
                var value = _studentsService.GetById(student.Id);
                
                _studentsService.Update(_mapper.Map<Student>(value));
                return Ok(_mapper.Map<Student>(value));
            }
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            Student user = _studentsService.GetById(id);
            if (user == null)
                return NotFound();
            else
            {
                _studentsService.Delete(user.Id);
                return Ok(user);
            }
        }
    }
}