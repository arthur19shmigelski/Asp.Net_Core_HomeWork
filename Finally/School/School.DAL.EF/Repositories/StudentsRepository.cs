using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.DAL.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL.EF.Repositories
{
    public class StudentsRepository : IRepository<Student>
    {
        private readonly AcademyContext _context;

        public StudentsRepository(AcademyContext context)
        {
            _context = context;
        }

        public void Create(Student item)
        {
            _context.Students.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Student student)
        {
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            else
                throw new ArgumentNullException(string.Format("Class {0} - method {1} === {2}",nameof(StudentsRepository), nameof(Delete), nameof(ArgumentNullException.Message)));
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return _context.Students.AsNoTracking().Where(predicate).ToList();
        }

        public Student Get(int id) => _context.Students.Find(id);

        public IEnumerable<Student> GetAll()
        {
                return _context.Students.AsNoTracking()
                .Include(s => s.Group)
                .ToList();
        }

        public void Update(Student item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
