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
            services.AddScoped<IRepository<Teacher>, BaseRepository<Teacher>>();
            services.AddScoped<IRepository<Student>, BaseRepository<Student>>();
            services.AddScoped<IRepository<StudentGroup>, BaseRepository<StudentGroup>>();
            services.AddScoped<IRepository<StudentRequest>, StudentRequestsRepository>();

            return services;
        }
    }
}
