using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Services.Course;
using School.Web.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : Controller
    {
        private readonly ICourseService _service;
        private readonly IMapper _mapper;
        public CoursesController(ICourseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CourseDto> Get()
        {
            return _mapper.Map<IEnumerable<CourseDto>>(_service.GetAll());
        }
    }
}
