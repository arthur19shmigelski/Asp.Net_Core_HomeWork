using Microsoft.Extensions.DependencyInjection;
using School.BLL.Models;
using School.BLL.Services.Base;
using School.BLL.Services.Course;
using School.BLL.Services.Student;
using School.BLL.Services.StudentGroup;
using School.BLL.Services.StudentRequest;
using School.BLL.Services.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IEntityService<Topic>, BaseEntityService<Topic>>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentGroupService, StudentGroupService>();
            services.AddScoped<IStudentRequestService, StudentRequestService>();

            return services;
        }
    }
}
