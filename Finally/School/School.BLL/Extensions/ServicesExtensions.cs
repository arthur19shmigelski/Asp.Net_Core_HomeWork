using Microsoft.Extensions.DependencyInjection;
using School.BLL.Models;
using School.BLL.Services.Base;
using School.BLL.Services.StudentRequest;

namespace School.BLL.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddBusinessLogicServicesFromBLL(this IServiceCollection services)
        {
            services.AddScoped<IEntityService<Topic>, BaseEntityService<Topic>>();
            services.AddScoped<IEntityService<Student>, BaseEntityService<Student>>();
            services.AddScoped<IEntityService<Course>, BaseEntityService<Course>>();
            services.AddScoped<IEntityService<Teacher>, BaseEntityService<Teacher>>();
            services.AddScoped<IEntityService<StudentGroup>, BaseEntityService<StudentGroup>>();
            services.AddScoped<IStudentRequestService, StudentRequestService>();

            return services;
        }
    }
}
