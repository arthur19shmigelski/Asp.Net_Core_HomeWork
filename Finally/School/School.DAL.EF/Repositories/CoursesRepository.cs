using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.DAL.EF.Contexts;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL.EF.Repositories
{
    public class CoursesRepository : IRepository<Course>
    {
        private readonly AcademyContext _context;

        public CoursesRepository(AcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses
                .Include(c => c.Topic)
                .ToList();
        }
        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public void Create(Course item)
        {
            _context.Courses.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Courses.Find(id);
            _context.Courses.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<Course> Find(Func<Course, bool> predicate)
        {
            return _context.Courses
                            .Where(predicate)
                            .AsQueryable()
                            .ToList();
        }

        public void Update(Course item)
        {
            var originalCourse = _context.Courses.Find(item.Id);

            originalCourse.Description = item.Description;
            originalCourse.Program = item.Program;
            originalCourse.Title = item.Title;
            originalCourse.Topic = item.Topic;
            originalCourse.TopicId = item.TopicId;

            _context.SaveChanges();
        }
    }
}