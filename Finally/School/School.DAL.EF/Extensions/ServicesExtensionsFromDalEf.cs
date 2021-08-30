using Microsoft.Extensions.DependencyInjection;
using School.BLL.Models;
using School.DAL.EF.Repositories;

namespace School.DAL.EF.Extensions
{
    public static class ServicesExtensionsFromDalEf
    {
        public static IServiceCollection AddBusinessLogicServicesFromDalEF(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Topic>, BaseRepository<Topic>>();
            services.AddScoped<IRepository<Course>, BaseRepository<Course>>();
            services.AddScoped<IRepository<Teacher>, TeachersRepository>();
            services.AddScoped<IRepository<Student>, StudentsRepository>();
            services.AddScoped<IRepository<StudentGroup>, StudentGroupsRepository>();
            services.AddScoped<IRepository<StudentRequest>, StudentRequestsRepository>();

            return services;
        }
    }
}
