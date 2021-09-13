using AutoMapper;
using School.Angular.Dto;
using School.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Angular.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(model => model.TopicName, map => map.MapFrom(c => c.Topic.Title))
                .ReverseMap();
        }
    }
}
