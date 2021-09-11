﻿using Microsoft.Extensions.DependencyInjection;
using School.BLL.Models;
using School.DAL.EF.Repositories;
using School.DAL.Interfaces;

namespace School.DAL.EF.Extensions
{
    public static class ServicesExtensionsFromDalEf
    {
        public static IServiceCollection AddBusinessLogicServicesFromDalEF(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Topic>, TopicRepository>();
            services.AddScoped<IRepository<Course>, CoursesRepository>();
            services.AddScoped<IRepository<Teacher>, TeachersRepository>();
            services.AddScoped<IRepository<Student>, StudentsRepository>();
            services.AddScoped<IRepository<StudentGroup>, StudentGroupsRepository>();
            services.AddScoped<IRepository<StudentRequest>, StudentRequestsRepository>();

            return services;
        }
    }
}