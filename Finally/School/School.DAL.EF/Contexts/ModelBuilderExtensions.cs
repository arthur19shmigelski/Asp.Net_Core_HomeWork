using Microsoft.EntityFrameworkCore;
using School.Core.Models;
using School.Core.Models.Enum;
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
                Description = "\tC# (си шарп) – объектно-ориентированный язык программирования, разработанный " +
                "компанией Microsoft. Прямой интерес такой крупной корпорации к языку гарантирует, что он " +
                "продолжит развиваться и находить применение в различных отраслях." + "\n\t" +
                "C Sharp впитал лучшие качества, а также унаследовал особенности " +
                "синтаксиса Java и C++. Применяется язык для веб-разработки, создания настольных и " +
                "мобильных приложений. Если вы записались на курс по C# в Минске для того, чтобы научиться " +
                "создавать web-проекты, то в дальнейшем вам необходимо освоить инструментарий .NET."

            };
            var topic2 = new Topic()
            {
                Id = 2,
                Title = "Java",
                Description = "\tЯзык программирования Java находится в числе лидеров во многих рейтингах: " +
                "TIOBE – на основе подсчёта результатов поисковых запросов, PYPL – по анализу популярности в поисковике Google," +
                " IEEE – по комплексу показателей, таких как упоминание в проектах, статьях, вакансиях и других. Такая популярность" +
                " обусловлена практически безграничными его возможностями и областями применения.\n\tJava не зависит от определённой платформы, " +
                "его называют безопасным, портативным, высокопроизводительным и динамичным языком."
            };
            var topic3 = new Topic()
            {
                Id = 3,
                Title = "Design",
                Description = "\tUI/UX и web-дизайн ориентирован на создание внешне привлекательных, " +
                "удобных в использовании и функциональных пользовательских интерфейсов. Чтобы достичь " +
                "успеха в этой сфере, необходимо обладать художественным вкусом, быть внимательным к деталям, " +
                "понимать принципы компьютерной графики и визуального дизайна, уметь работать с инструментами " +
                "(например, Adobe Photoshop, Adobe Illustrator, Sketch, Figma)."
            };
            modelBuilder.Entity<Topic>().HasData(topic1, topic2, topic3);

            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 9 Courses*/
            var course1 = new Course()
            {
                Id = 1,
                Title = "C#",
                Description = "Базовый уровень",
                Program = "1. Вводное. Установка окружения(C#, Visual Studio). Запуск первой программы Console Application." +
                "\n2. Типы данных. Переменные. Операторы." +
                "\n3. Операторы if/switch." +
                "\n4. Циклы." +
                "\n5. И многое другое...",
                TopicId = 1
            };

            var course2 = new Course()
            {
                Id = 2,
                Title = "Java",
                Description = "Базовый уровень",
                Program = "1. Вводное. Установка окружения(Java, Intellij IDEA). Запуск первой программы." +
                "\n2. Типы данных. Переменные. Операторы." +
                "\n3. Операторы if/switch." +
                "\n4. Циклы." +
                "\n5. И многое другое...",
                TopicId = 2
            };

            var course3 = new Course()
            {
                Id = 3,
                Title = "Web Design",
                Description = "Базовый уровень",
                Program = "1. Принципы визуального дизайна." +
                          "\n2. Особенности UI/UX/web дизайна." +
                          "\n3. Основы композиции." +
                          "\n4. Правила работы со шрифтами." +
                          "\n5. И многое другое...",
                TopicId = 3
            };
            var course4 = new Course()
            {
                Id = 4,
                Title = "Промышленная разработка ПО на ASP.NET",
                Description = "Средний уровень",
                Program = "1. Основы MVC: -Паттерн MVC, MVC контроллеры, разработка представлений." +
                "\n2. Основы WebApi: -Архитектура REST; -Проектирование RESTful сервисов, Self-Hosted приложения" +
                "\n3. Работа с моделями: -Многослойная архитектура; -Добавление слоя бизнес-логики; -DI и паттерн IoC" +
                "\n4. Работа с данными: -Понятие ORM, Entity Framework; -Основные подходы к проектированию БД: CodeFirst, DatabaseFirst, ModelFirst" +
                "\n5. И многое другое...",
                TopicId = 1
            };

            var course5 = new Course()
            {
                Id = 5,
                Title = "Промышленная разработка ПО на Java",
                Description = "Средний уровень",
                Program = "1. Основы Apache Maven." +
                "\n2. Инженерные техники при работе с Apache Maven." +
                "\n3. Работа с моделями: -Многослойная архитектура; -Добавление слоя бизнес-логики, паттерн DAO; -Практика." +
                "\n4. Работа с данными: Основные подходы к проектированию БД, Введение в БД и SQL." +
                "\n5. И многое другое...",
                TopicId = 2
            };

            var course6 = new Course()
            {
                Id = 6,
                Title = "Веб-разработка на языках HTML, CSS и JavaScript ",
                Description = "Средний уровень",
                Program = "1. Знакомство с библиотекой React." +
                          "\n2. Настройка Git и Webpack." +
                          "\n3. Глубокое изучение JavaScript." +
                          "\n4. Твоя первая большая курсовая работа в команде (простой суши-магазин)." +
                          "\n5. И многое другое...",
                TopicId = 3
            };
            var course7 = new Course()
            {
                Id = 7,
                Title = "Unity",
                Description = "Высокий уровень",
                Program = "1. Введение в Unity. Hello world с Unity." +
                "\n2. Scripts (Cкрипты). Part 1: -Методология; -Игровые объекты и компоненты; -Cлои, ввод данных, теги." +
                "\n3. Scripts (Скрипты). Part 2: -Manual: Immediate Mode GUI (IMGUI); -Сопрограммы." +
                "\n4. Инструментарий для разработки 2D-игр." +
                "\n5. И многое другое...",
                TopicId = 1
            };

            var course8 = new Course()
            {
                Id = 8,
                Title = "Full-stack developer",
                Description = "Высокий уровень",
                Program = "1. JQuery." +
                "\n2. EscmaScript6." +
                "\n3. Расширенные возможность JavaScript" +
                "\n4. Работа с данными: Основные подходы к проектированию БД, Введение в БД и SQL" +
                "\n5. И многое другое...",
                TopicId = 2
            };

            var course9 = new Course()
            {
                Id = 9,
                Title = "Angular, React, Vue",
                Description = "Высокий уровень",
                Program = "1. Знакомство с библиотекой React" +
                          "\n2.Знакомство с библиотекой Angular" +
                          "\n3. Знакомство с библиотекой Vue" +
                          "\n4. Твоя первая большая курсовая работа в команде (3 проекта на каждом фрэймворке - магазин доставки цветов)" +
                          "\n5. И многое другое...",
                TopicId = 3
            };

            modelBuilder.Entity<Course>().HasData(course1, course2, course3, course4, course5, course6, course7, course8, course9);

            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 5 Teachers*/
            var teacher1 = new Teacher()
            {
                Id = 1,
                FirstName = "Vadim",
                LastName = "Korotkov",
                LinkToProfile = "https://www.linkedin.com/feed/Korotkov",
                Bio = "My name is Vadim Korotkov. I'am full-stack developer. I know all language, frameworks",
                Age = 30,
                Email = "Korotkov@mail.ru",
                Phone = "+375291111111"
            };
            var teacher2 = new Teacher()
            {
                Id = 2,
                FirstName = "Sergey",
                LastName = "Gromov",
                LinkToProfile = "https://www.linkedin.com/feed/Gromov",
                Bio = "My name is Sergey Gromov. I'am a back-end developer on .Net Framework + Java (JS).",
                Age = 32,
                Email = "Gromov@yandex.ru",
                Phone = "+375292222222"
            };
            var teacher3 = new Teacher()
            {
                Id = 3,
                FirstName = "Andrew",
                LastName = "Kamilov",
                LinkToProfile = "https://www.linkedin.com/feed/Kamilov",
                Bio = "My name is Andrew Kamilov. I'am front-end developer, know some modern frameworks (Angular, Vue, React)",
                Age = 36,
                Email = "Kamilov@yandex.ru",
                Phone = "+375293333333"
            };

            var teacher4 = new Teacher()
            {
                Id = 4,
                FirstName = "Marina",
                LastName = "Kuzmina",
                LinkToProfile = "https://www.linkedin.com/feed/Kuzmina",
                Bio = "My name is Marina Kuzmina. I am a Design teacher",
                Age = 34,
                Email = "Kuzmina@yandex.ru",
                Phone = "+375296561723"
            };
            var teacher5 = new Teacher()
            {
                Id = 5,
                FirstName = "Vladimir",
                LastName = "Vorobei",
                LinkToProfile = "https://www.linkedin.com/feed/Vorobei",
                Bio = "My name is Vladimir Vorobei. I am a C# language teacher",
                Age = 27,
                Email = "Vorobei@yandex.ru",
                Phone = "+375290989093"
            };
            modelBuilder.Entity<Teacher>().HasData(teacher1, teacher2, teacher3, teacher4, teacher5);

            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 15 students*/



            var student1 = new Student()
            {
                Id = 1,
                FirstName = "Oleg",
                LastName = "Fedorov",
                Email = "Fedorov@gmail.com",
                Age = 22,
                Phone = "+375291111111",
                Type = StudentType.Online,
            };
            var student2 = new Student()
            {
                Id = 2,
                FirstName = "Andrey",
                LastName = "Antonov",
                Email = "Antonov@gmail.com",
                Age = 26,
                Phone = "+375292222222",
                Type = StudentType.Mix,
            };
            var student3 = new Student()
            {
                Id = 3,
                FirstName = "Ivan",
                LastName = "Petrov",
                Email = "Petrov@gmail.com",
                Age = 17,
                Phone = "+375443333333",
                Type = StudentType.InClass,
            };
            var student4 = new Student()
            {
                Id = 4,
                FirstName = "Sergey",
                LastName = "Ivashko",
                Email = "Ivashko@gmail.com",
                Age = 19,
                Phone = "+375444444444",
                Type = StudentType.Online,
            };
            var student5 = new Student()
            {
                Id = 5,
                FirstName = "Arthur",
                LastName = "Shmigelski",
                Email = "Shmigelski@gmail.com",
                Age = 25,
                Phone = "+375295555555",
                Type = StudentType.Online,
            };
            var student6 = new Student()
            {
                Id = 6,
                FirstName = "Maxim",
                LastName = "Sergeenko",
                Email = "Sergeenko@yandex.com",
                Age = 25,
                Phone = "+375446666666",
                Type = StudentType.Mix,
            };
            var student7 = new Student()
            {
                Id = 7,
                FirstName = "Vladimir",
                LastName = "Micinat",
                Email = "Micinat@gmail.com",
                Age = 50,
                Phone = "+375447777777",
                Type = StudentType.Mix,
            };
            var student8 = new Student()
            {
                Id = 8,
                FirstName = "Anatoliy",
                LastName = "Frunze",
                Email = "Frunze@mail.ru",
                Age = 46,
                Phone = "+375448888888",
                Type = StudentType.InClass,
            };
            var student9 = new Student()
            {
                Id = 9,
                FirstName = "Polina",
                LastName = "Vaneeva",
                Email = "VaneevaPolina@gmail.com",
                Age = 40,
                Phone = "+375449999999",
                Type = StudentType.Mix,
            };
            var student10 = new Student()
            {
                Id = 10,
                FirstName = "Miron",
                LastName = "Yakimov",
                Email = "YakimovMiron@gmail.com",
                Age = 39,
                Phone = "+375441010101",
                Type = StudentType.InClass,
            };
            var student11 = new Student()
            {
                Id = 11,
                FirstName = "Nikita",
                LastName = "Moroz",
                Email = "MorozNikita@gmail.com",
                Age = 22,
                Phone = "+375440110111",
                Type = StudentType.InClass,
            };
            var student12 = new Student()
            {
                Id = 12,
                FirstName = "Vitalik",
                LastName = "Ponimash",
                Email = "PonimashVitalik@gmail.com",
                Age = 25,
                Phone = "+375441212123",
                Type = StudentType.Online,
            };
            var student13 = new Student()
            {
                Id = 13,
                FirstName = "Irina",
                LastName = "Fistashka",
                Email = "FistashkaIrina@yandex.by",
                Age = 29,
                Phone = "+375444444444",
                Type = StudentType.Online,
            };
            var student14 = new Student()
            {
                Id = 14,
                FirstName = "Alena",
                LastName = "Filimonova",
                Email = "Filimonova@gmail.com",
                Age = 20,
                Phone = "+375441534545",
                Type = StudentType.Mix,
            };
            var student15 = new Student()
            {
                Id = 15,
                FirstName = "Sergey",
                LastName = "Efremov",
                Email = "EfremovSergey@mail.ru",
                Age = 25,
                Phone = "+375441232323",
                Type = StudentType.Online,
            };
            modelBuilder.Entity<Student>().HasData(
               student1, student2, student3,
               student4, student5, student6,
               student7, student8, student9,
               student10, student11, student12,
               student13, student14, student15);

            modelBuilder.Entity<StudentRequest>().HasData(
                new StudentRequest
                {
                    Id = 1,
                    CourseId = course1.Id,
                    ReadyToStartDate = new DateTime(2021, 8, 20),
                    StudentId = student1.Id,
                    Comments = "Хочу учиться на C# (basic) ",
                    Status = RequestStatus.Open
                },
                new StudentRequest
                {
                    Id = 2,
                    CourseId = course1.Id,
                    ReadyToStartDate = new DateTime(2021, 7, 11),
                    StudentId = student2.Id,
                    Comments = "Хочу учиться на C# (basic)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 3,
                    CourseId = course2.Id,
                    ReadyToStartDate = new DateTime(2021, 7, 15),
                    StudentId = student3.Id,
                    Comments = "Хочу учиться на Java (basic)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 4,
                    CourseId = course2.Id,
                    ReadyToStartDate = new DateTime(2021, 7, 11),
                    StudentId = student4.Id,
                    Comments = "Хочу учиться на Java (basic)",
                    Status = RequestStatus.Open
                },
                new StudentRequest
                {
                    Id = 5,
                    CourseId = course3.Id,
                    ReadyToStartDate = new DateTime(2021, 9, 5),
                    StudentId = student5.Id,
                    Comments = "Хочу учиться на Design (basic)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 6,
                    CourseId = course3.Id,
                    ReadyToStartDate = new DateTime(2021, 8, 15),
                    StudentId = student6.Id,
                    Comments = "Хочу учиться на Design (basic)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 7,
                    CourseId = course4.Id,
                    ReadyToStartDate = new DateTime(2021, 9, 2),
                    StudentId = student7.Id,
                    Comments = "Хочу учиться на C# (средний)",
                    Status = RequestStatus.Open
                },
                new StudentRequest
                {
                    Id = 8,
                    CourseId = course4.Id,
                    ReadyToStartDate = new DateTime(2021, 8, 22),
                    StudentId = student8.Id,
                    Comments = "Хочу учиться на С# (средний)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 9,
                    CourseId = course5.Id,
                    ReadyToStartDate = new DateTime(2021, 9, 3),
                    StudentId = student9.Id,
                    Comments = "Хочу учиться на Java (средний)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 10,
                    CourseId = course5.Id,
                    ReadyToStartDate = new DateTime(2021, 7, 11),
                    StudentId = student10.Id,
                    Comments = "Хочу учиться на Java (средний)",
                    Status = RequestStatus.Open
                }
            );
        }
    }
}