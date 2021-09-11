using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.DAL.EF.Contexts;
using School.DAL.Interfaces;
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

        public void Delete(int id)
        {
            var item = _context.Students.Find(id);
            _context.Students.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return _context.Students
                                        .Where(predicate)
                                        .AsQueryable()
                                        .ToList();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.AsNoTracking()
            .Include(s => s.Group)
            .ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public void Update(Student item)
        {
            var originalStudent = _context.Students.Find(item.Id);

            originalStudent.BirthDate = item.BirthDate;
            originalStudent.Email = item.Email;
            originalStudent.FirstName = item.FirstName;
            originalStudent.LastName = item.LastName;
            originalStudent.Group = item.Group;
            originalStudent.GroupId = item.GroupId;
            originalStudent.Phone = item.Phone;
            originalStudent.StartDate = item.StartDate;
            originalStudent.Type = item.Type;

            _context.SaveChanges();
        }
    }
}