using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using System;

namespace School.DAL.EF.Contexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 3 Topics*/
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
            var topic3 = new Topic()
            {
                Id = 3,
                Title = "Design",
                Description = "UI/UX, Motion Design, 3D Design"
            };
            modelBuilder.Entity<Topic>().HasData(topic1, topic2, topic3);

            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 3 Courses*/
            var course1 = new Course()
            {
                Id = 1,
                Title = "Introduction to C#",
                Description = "\tC# (си шарп) – объектно-ориентированный язык программирования, разработанный " +
                "компанией Microsoft. Прямой интерес такой крупной корпорации к языку гарантирует, что он " +
                "продолжит развиваться и находить применение в различных отраслях." + "\n\t"+
                "C Sharp впитал лучшие качества, а также унаследовал особенности " +
                "синтаксиса Java и C++. Применяется язык для веб-разработки, создания настольных и " +
                "мобильных приложений. Если вы записались на курс по C# в Минске для того, чтобы научиться " +
                "создавать web-проекты, то в дальнейшем вам необходимо освоить инструментарий .NET.",
                Program = "1. Вводное. Установка окружения(C#, Visual Studio). Запуск первой программы Console Application." +
                "2. Типы данных. Переменные. Операторы." +
                "3. Операторы if/switch" +
                "4. Циклы" +
                "5. И многое другое",
                TopicId = 1
            };

            var course2 = new Course()
            {
                Id = 2,
                Title = "Introduction to Java",
                Description = "Язык программирования Java находится в числе лидеров во многих рейтингах: " +
                "TIOBE – на основе подсчёта результатов поисковых запросов, PYPL – по анализу популярности в поисковике Google," +
                " IEEE – по комплексу показателей, таких как упоминание в проектах, статьях, вакансиях и других. Такая популярность" +
                " обусловлена практически безграничными его возможностями и областями применения. Java не зависит от определённой платформы, " +
                "его называют безопасным, портативным, высокопроизводительным и динамичным языком.",
                Program = "1. Вводное. Установка окружения(Java, Intellij IDEA). Запуск первой программы." +
                "2. Типы данных. Переменные. Операторы." +
                "3. Операторы if/switch" +
                "4. Циклы" +
                "5. И многое другое",
                TopicId = 2
            };

            var course3 = new Course()
            {
                Id = 3,
                Title = "Web Design",
                Description = "UI/UX и web-дизайн ориентирован на создание внешне привлекательных, " +
                "удобных в использовании и функциональных пользовательских интерфейсов. Чтобы достичь " +
                "успеха в этой сфере, необходимо обладать художественным вкусом, быть внимательным к деталям, " +
                "понимать принципы компьютерной графики и визуального дизайна, уметь работать с инструментами " +
                "(например, Adobe Photoshop, Adobe Illustrator, Sketch, Figma).",
                Program = "1. Принципы визуального дизайна" +
                          "2. Особенности UI/UX/web дизайна" +
                          "3. Основы композиции" +
                          "4. Правила работы со шрифтамин" +
                          "5. И много другой информации",
                TopicId = 3
            };

            modelBuilder.Entity<Course>().HasData(course1, course2, course3);

            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 5 Teachers*/
            var teacher1 = new Teacher()
            {
                Id = 1,
                FirstName = "Vadim",
                LastName = "Korotkov",
                LinkToProfile = "https://www.linkedin.com/feed/Korotkov",
                Bio = "My name is Vadim Korotkov.",
                BirthDate = new DateTime(1977, 01, 01),
                Email = "Korotkov@mail.ru",
                Phone = "+375291111111"
            };
            var teacher2 = new Teacher()
            {
                Id = 2,
                FirstName = "Sergey",
                LastName = "Gromov",
                LinkToProfile = "https://www.linkedin.com/feed/Gromov",
                Bio = "My name is Sergey Gromov.",
                BirthDate = new DateTime(1944, 02, 02),
                Email = "Gromov@yandex.ru",
                Phone = "+375292222222"
            };
            var teacher3 = new Teacher()
            {
                Id = 3,
                FirstName = "Andrew",
                LastName = "Kamilov",
                LinkToProfile = "https://www.linkedin.com/feed/Kamilov",
                Bio = "My name is Andrew Kamilov.",
                BirthDate = new DateTime(1956, 03, 03),
                Email = "Kamilov@yandex.ru",
                Phone = "+375293333333"
            };

            modelBuilder.Entity<Teacher>().HasData(teacher1, teacher2, teacher3);

            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 3 StudentGroups*/
            var group1 = new StudentGroup()
            {
                Id = 1,
                Title = "Basic_C#_01.01",
                TeacherId = teacher1.Id,
                CourseId = course1.Id,
                Status = BLL.Models.Enum.GroupStatus.NotStarted,
                StartDate = new DateTime(2022, 01, 01)
            };
            var group2 = new StudentGroup()
            {
                Id = 2,
                Title = "Java_02_02",
                TeacherId = teacher2.Id,
                CourseId = course2.Id,
                Status = BLL.Models.Enum.GroupStatus.NotStarted,
                StartDate = new DateTime(2023, 02, 02)
            };
            var group3 = new StudentGroup()
            {
                Id = 3,
                Title = "Motion Design_03_03",
                TeacherId = teacher3.Id,
                CourseId = course3.Id,
                Status = BLL.Models.Enum.GroupStatus.NotStarted,
                StartDate = new DateTime(2024, 03, 03)
            };

            modelBuilder.Entity<StudentGroup>().HasData(group1, group2, group3);


            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 15 students*/
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "Oleg",
                    LastName = "Fedorov",
                    Email = "Fedorov@gmail.com",
                    BirthDate = new DateTime(1998, 01, 01),
                    Phone = "+375291111111",
                    GroupId = group1.Id,
                    Type = BLL.Models.Enum.StudentType.Online,
                    StartDate = DateTime.Today
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Andrey",
                    LastName = "Antonov",
                    Email = "Antonov@gmail.com",
                    BirthDate = new DateTime(1990, 02, 02),
                    Phone = "+375292222222",
                    GroupId = group2.Id,
                    Type = BLL.Models.Enum.StudentType.Mix,
                    StartDate = new DateTime(2021, 10, 10)
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Ivan",
                    LastName = "Petrov",
                    Email = "Petrov@gmail.com",
                    BirthDate = new DateTime(1988, 03, 03),
                    Phone = "+375443333333",
                    GroupId = group3.Id,
                    Type = BLL.Models.Enum.StudentType.InClass,
                    StartDate = new DateTime(2023, 01, 01)

                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Sergey",
                    LastName = "Ivashko",
                    Email = "Ivashko@gmail.com",
                    BirthDate = new DateTime(2000, 04, 04),
                    Phone = "+375444444444",
                    GroupId = group1.Id,
                    Type = BLL.Models.Enum.StudentType.Online,
                    StartDate = new DateTime(2022, 05, 05)
                },
                new Student()
                {
                    Id = 5,
                    FirstName = "Arthur",
                    LastName = "Shmigelski",
                    Email = "Shmigelski@gmail.com",
                    BirthDate = new DateTime(1998, 05, 05),
                    Phone = "+375295555555",
                    GroupId = group2.Id,
                    Type = BLL.Models.Enum.StudentType.Online,
                    StartDate = new DateTime(2022, 06, 06)
                },
                new Student()
                {
                    Id = 6,
                    FirstName = "Maxim",
                    LastName = "Sergeenko",
                    Email = "Sergeenko@yandex.com",
                    BirthDate = new DateTime(1997, 06, 06),
                    Phone = "+375446666666",
                    GroupId = group3.Id,
                    Type = BLL.Models.Enum.StudentType.Mix,
                    StartDate = new DateTime(2020, 02, 02)
                },
                new Student()
                {
                    Id = 7,
                    FirstName = "Vladimir",
                    LastName = "Micinat",
                    Email = "Micinat@gmail.com",
                    BirthDate = new DateTime(1994, 07, 07),
                    Phone = "+375447777777",
                    GroupId = group1.Id,
                    Type = BLL.Models.Enum.StudentType.Mix,
                    StartDate = new DateTime(2022, 05, 05)
                },
                new Student()
                {
                    Id = 8,
                    FirstName = "Anatoliy",
                    LastName = "Frunze",
                    Email = "Frunze@mail.ru",
                    BirthDate = new DateTime(1973, 08, 08),
                    Phone = "+375448888888",
                    GroupId = group2.Id,
                    Type = BLL.Models.Enum.StudentType.InClass,
                    StartDate = new DateTime(2022, 05, 05)
                },
                new Student()
                {
                    Id = 9,
                    FirstName = "Polina",
                    LastName = "Vaneeva",
                    Email = "VaneevaPolina@gmail.com",
                    BirthDate = new DateTime(1992, 09, 09),
                    Phone = "+375449999999",
                    GroupId = group3.Id,
                    Type = BLL.Models.Enum.StudentType.Mix,
                    StartDate = new DateTime(2021, 03, 03)
                },
                new Student()
                {
                    Id = 10,
                    FirstName = "Miron",
                    LastName = "Yakimov",
                    Email = "YakimovMiron@gmail.com",
                    BirthDate = new DateTime(1999, 10, 10),
                    Phone = "+375441010101",
                    GroupId = group1.Id,
                    Type = BLL.Models.Enum.StudentType.InClass,
                    StartDate = new DateTime(2023, 02, 02)
                },
                new Student()
                {
                    Id = 11,
                    FirstName = "Nikita",
                    LastName = "Moroz",
                    Email = "MorozNikita@gmail.com",
                    BirthDate = new DateTime(1999, 11, 03),
                    Phone = "+375440110111",
                    GroupId = group2.Id,
                    Type = BLL.Models.Enum.StudentType.InClass,
                    StartDate = new DateTime(2022, 07, 08)
                },
                new Student()
                {
                    Id = 12,
                    FirstName = "Vitalik",
                    LastName = "Ponimash",
                    Email = "PonimashVitalik@gmail.com",
                    BirthDate = new DateTime(1996, 02, 01),
                    Phone = "+375441212123",
                    GroupId = group3.Id,
                    Type = BLL.Models.Enum.StudentType.Online,
                    StartDate = new DateTime(2022, 05, 06)
                },
                new Student()
                {
                    Id = 13,
                    FirstName = "Irina",
                    LastName = "Fistashka",
                    Email = "FistashkaIrina@yandex.by",
                    BirthDate = new DateTime(2000, 11, 10),
                    Phone = "+375444444444",
                    GroupId = group1.Id,
                    Type = BLL.Models.Enum.StudentType.Online,
                    StartDate = new DateTime(2021, 09, 09)
                },
                new Student()
                {
                    Id = 14,
                    FirstName = "Alena",
                    LastName = "Filimonova",
                    Email = "Filimonova@gmail.com",
                    BirthDate = new DateTime(2000, 11, 11),
                    Phone = "+375441534545",
                    GroupId = group2.Id,
                    Type = BLL.Models.Enum.StudentType.Mix,
                    StartDate = new DateTime(2021, 08, 08)
                },
                new Student()
                {
                    Id = 15,
                    FirstName = "Sergey",
                    LastName = "Efremov",
                    Email = "EfremovSergey@mail.ru",
                    BirthDate = new DateTime(1988, 10, 15),
                    Phone = "+375441232323",
                    GroupId = group3.Id,
                    Type = BLL.Models.Enum.StudentType.Online,
                    StartDate = new DateTime(2021, 09, 09)
                }
            );
        }
    }
}