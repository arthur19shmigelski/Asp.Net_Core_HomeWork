using School.BLL.Models;
using School.DAL.EF.Contexts;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL.EF.Repositories
{
    public class TeachersRepository : IRepository<Teacher>
    {
        private readonly AcademyContext _context;
        public TeachersRepository(AcademyContext context)
        {
            _context = context;
        }

        public void Create(Teacher item)
        {
            _context.Teachers.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);

            var groups = _context.StudentGroups.Where(c => c.TeacherId == id).Select(c => c).ToList();

            foreach (var item in groups)
            {
                item.TeacherId = null;
                item.Teacher = null;
                _context.StudentGroups.Update(item);
            }

            _context.Teachers.Remove(teacher);

            _context.SaveChanges();
        }

        public IEnumerable<Teacher> Find(Func<Teacher, bool> predicate)
        {
            return _context.Teachers
                                        .Where(predicate)
                                        .AsQueryable()
                                        .ToList();
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public Teacher GetById(int id)
        {
            return _context.Teachers.Find(id);
        }

        public void Update(Teacher item)
        {
            var originalTeacher = _context.Teachers.Find(item.Id);

            originalTeacher.Bio = item.Bio;
            originalTeacher.BirthDate = item.BirthDate;
            originalTeacher.Email = item.Email;
            originalTeacher.FirstName = item.FirstName;
            originalTeacher.LastName = item.LastName;
            originalTeacher.LinkToProfile = item.LinkToProfile;
            originalTeacher.Phone = item.Phone;

            _context.SaveChanges();
        }
    }
}