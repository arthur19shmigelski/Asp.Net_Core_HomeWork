using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.EF.Contexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var topic1 = new Topic()
            {
                Id = 1,
                Title = ".Net",
                Description = ".Net (ASP.NET, Unity)"
                
            };
            var topic2 = new Topic()
            {
                Id = 2,
                Title = "Java",
                Description = "Full-stack, JS, Spring"
            };
            modelBuilder.Entity<Topic>().HasData(topic1, topic2);

            var course1 = new Course()
            {
                Id = 10,
                Title = "Introduction to C#",
                Description = "Introduction to C#",
                Program = "1. Getting Started",
                TopicId = 1
            };

            var course2 = new Course()
            {
                Id = 11,
                Title = "Introduction to Java",
                Description = "Introduction to Java",
                Program = "1. Getting Started",
                TopicId = 2
            };

            var course3 = new Course()
            {
                Id = 12,
                Title = "ASP.NET",
                Description = "Web with ASP.NET",
                Program = "1. Controllers and MVC",
                TopicId = 1
            };

            var course4 = new Course()
            {
                Id = 13,
                Title = "Unity",
                Description = "Unity Game Development",
                Program = "1. What is Unity",
                TopicId = 1
            };

            modelBuilder.Entity<Course>().HasData(course1, course2, course3, course4);

            var teacher1 = new Teacher()
            {
                Id = 1,
                FirstName = "Vadim",
                LastName = "Korotkov",
                LinkToProfile = "https://www.linkedin.com/feed/",
                Bio = "My name is Vadim.",
                BirthDate = new DateTime(1977,07,07),
                Email = "Korotkov@mail.ru",
                Phone = "+375292929292"
            };
            var teacher2 = new Teacher()
            {
                Id = 2,
                FirstName = "Sergey",
                LastName = "Gromov",
                LinkToProfile = "https://www.linkedin.com/feed/",
                Bio = "My name is Sergey.",
                BirthDate = new DateTime(1944, 01, 02),
                Email = "Gromov@yandex.ru",
                Phone = "+37533333333"
            };
            modelBuilder.Entity<Teacher>().HasData(teacher1, teacher2);

            var group1 = new StudentGroup()
            {
                Id = 1,
                Title = "ASPNET_21_1",
                TeacherId = teacher1.Id,
                CourseId = course1.Id,
                Status= BLL.Models.Enum.GroupStatus.NotStarted,
                StartDate = new DateTime(2022, 12,12)
            };
            var group2 = new StudentGroup()
            {
                Id = 2,
                Title = "Java_23_4",
                TeacherId = teacher1.Id,
                CourseId = course2.Id,
                Status = BLL.Models.Enum.GroupStatus.Started,
                StartDate = new DateTime(2020, 10, 29)
            };
            modelBuilder.Entity<StudentGroup>().HasData(group1, group2);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Oleg",
                    LastName = "Fedorov",
                    Email = "Fedorov@gmail.com",
                    BirthDate = new DateTime(1998,12,12),
                    Phone = "+3752912312323",
                    GroupId = 1,
                    Type = BLL.Models.Enum.StudentType.Online,
                    StartDate = DateTime.Today
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Andrey",
                    LastName = "Antonov",
                    Email = "Antonov@gmail.com",
                    BirthDate = new DateTime(1990, 10, 10),
                    Phone = "+37529111111",
                    GroupId = 2,
                    Type = BLL.Models.Enum.StudentType.Mix,
                    StartDate = new DateTime(2021, 10, 10)
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Ivan",
                    LastName = "Petrov",
                    Email = "Petrov@gmail.com",
                    BirthDate = new DateTime(1988, 08, 08),
                    Phone = "+375445765647",
                    GroupId = 1,
                    Type = BLL.Models.Enum.StudentType.InClass,
                    StartDate = new DateTime(2023, 01, 01)

                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Sergey",
                    LastName = "Ivashko",
                    Email = "Ivashko@gmail.com",
                    BirthDate = new DateTime(2000, 10, 10),
                    Phone = "+375444444444",
                    GroupId = 2,
                    Type = BLL.Models.Enum.StudentType.Online,
                    StartDate = new DateTime(2022, 05, 05)
                }
            );

        }
    }
}
