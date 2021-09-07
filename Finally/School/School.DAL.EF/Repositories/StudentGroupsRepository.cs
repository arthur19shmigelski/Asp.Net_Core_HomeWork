using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.BLL.ShortModels;
using School.DAL.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL.EF.Repositories
{
    public class StudentGroupsRepository : BaseRepository<StudentGroup>
    {
        private readonly AcademyContext _context;

        public StudentGroupsRepository(AcademyContext context) : base(context)
        {
            _context = context;
        }

       
        public override StudentGroup Get(int id) => _context.StudentGroups.Include(g => g.Students).First(g => g.Id == id);

        public override IEnumerable<StudentGroup> GetAll()
        {
            return _context.StudentGroups.Include(g => g.Teacher).ToList();
        }

        public override void Update(StudentGroup item)
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
    }
}