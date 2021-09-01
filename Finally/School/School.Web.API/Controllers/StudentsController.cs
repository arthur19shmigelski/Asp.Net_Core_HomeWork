using Microsoft.AspNetCore.Mvc;
using School.BLL.Models;
using School.BLL.Services.Base;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace School.Web.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IEntityService<Student> _studentsService;

        public StudentsController(IEntityService<Student> studentService)
        {
            _studentsService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            var students = _studentsService.GetAll();
            return Ok(students);
        }

        // GET api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            Student student = _studentsService.GetById(id);
            if (student == null)
                return NotFound();
            return new ObjectResult(student);
        }


        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student student)
        {
            if(student != null)
            {
                _studentsService.Create(student);
                return new ObjectResult(student);
            }
            return BadRequest();
        }

        // PUT api/users/
        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, "Студент создан")]
        public async Task<ActionResult<Student>> Put(Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            //Пересмотреть эту часть, потому что когда выполняю этот метод GetById выпадает error, что сущность с этим айди уже tracking...
            //if (_studentsService.GetById(student.Id) == null)
            //{
            //    return NotFound();
            //}
            _studentsService.Update(student);
            return Ok(student);
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            Student user = _studentsService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            _studentsService.Delete(user);
            return Ok(user);
        }
    }
}