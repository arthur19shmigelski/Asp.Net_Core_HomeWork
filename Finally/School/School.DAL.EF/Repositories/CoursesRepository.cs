using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.DAL.EF.Contexts;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.DAL.EF.Repositories
{
    public class CoursesRepository : IRepository<Course>
    {
        private readonly AcademyContext _context;

        public CoursesRepository(AcademyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses
                .Include(c => c.Topic)
                .ToListAsync();
        }
        public async Task<Course> GetById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task Create(Course item)
        {
            await _context.Courses.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item =  _context.Courses.FindAsync(id);
            _context.Courses.Remove(item.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> Find(Func<Course, bool> predicate)
        {
            return await _context.Courses
                            .Where(predicate)
                            .AsQueryable()
                            .ToListAsync();
        }

        public async Task Update(Course item)
        {
            var originalCourse = _context.Courses.Find(item.Id);

            originalCourse.Description = item.Description;
            originalCourse.Program = item.Program;
            originalCourse.Title = item.Title;
            originalCourse.Topic = item.Topic;
            originalCourse.TopicId = item.TopicId;

            await _context.SaveChangesAsync();
        }
    }
}