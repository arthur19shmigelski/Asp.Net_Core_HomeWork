using System.Collections.Generic;
using System.Linq;
using School.BLL.Models;
using School.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace School.DAL.EF.Repositories
{
    public class CoursesRepository : BaseRepository<Course>
    {
        private readonly AcademyContext _context;

        public CoursesRepository(AcademyContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Course> GetAll()
        {
            return _context.Courses
                .Include(c => c.Topic)
                .ToList();
        }

        public override void Update(Course item)
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