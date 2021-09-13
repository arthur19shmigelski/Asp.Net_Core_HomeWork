using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.DAL.EF.Contexts;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL.EF.Repositories
{
    public class StudentGroupsRepository : IRepository<StudentGroup>
    {
        private readonly AcademyContext _context;

        public StudentGroupsRepository(AcademyContext context)
        {
            _context = context;
        }

        public StudentGroup GetById(int id)
        {
            return _context.StudentGroups.Include(g => g.Students).First(g => g.Id == id);
        }
        public IEnumerable<StudentGroup> GetAll()
        {
            return  _context.StudentGroups.Include(g => g.Teacher).ToList();
        }

        public void Update(StudentGroup item)
        {
            var originalStudentGroup = _context.StudentGroups.Find(item.Id);

            originalStudentGroup.Course = item.Course;
            originalStudentGroup.CourseId = item.CourseId;
            originalStudentGroup.StartDate = item.StartDate;
            originalStudentGroup.Status = item.Status;
            originalStudentGroup.Students = item.Students;
            originalStudentGroup.Teacher = item.Teacher;
            originalStudentGroup.TeacherId = item.TeacherId;
            originalStudentGroup.Title = item.Title;

            _context.SaveChanges();
        }

        public IEnumerable<StudentGroup> Find(Func<StudentGroup, bool> predicate)
        {
            return _context.StudentGroups
                           .Where(predicate)
                           .AsQueryable()
                           .ToList();
        }

        public void Create(StudentGroup item)
        {
            _context.StudentGroups.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.StudentGroups.Find(id);
            _context.StudentGroups.Remove(item);
            _context.SaveChanges();
        }
    }
}