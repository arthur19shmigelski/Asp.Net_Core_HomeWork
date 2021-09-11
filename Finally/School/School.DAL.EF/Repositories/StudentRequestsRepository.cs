using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.DAL.EF.Contexts;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL.EF.Repositories
{
    public class StudentRequestsRepository : IRepository<StudentRequest>
    {
        private readonly AcademyContext _context;

        public StudentRequestsRepository(AcademyContext context)
        {
            _context = context;
        }

        public void Create(StudentRequest item)
        {
            _context.StudentRequests.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.StudentRequests.Find(id);
            _context.StudentRequests.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<StudentRequest> Find(Func<StudentRequest, bool> predicate)
        {
            return _context.StudentRequests
                            .Where(predicate)
                            .AsQueryable()
                            .ToList();
        }

        public IEnumerable<StudentRequest> GetAll()
        {
            return _context.StudentRequests
                .Include(r => r.Student)
                .Include(r => r.Course)
                .ToList();
        }

        public StudentRequest GetById(int id)
        {
            return _context.StudentRequests.Find(id);
        }

        public void Update(StudentRequest item)
        {
            var originalStudentRequest = _context.StudentRequests.Find(item.Id);

            originalStudentRequest.Comments = item.Comments;
            originalStudentRequest.Course = item.Course;
            originalStudentRequest.CourseId = item.CourseId;
            originalStudentRequest.Created = item.Created;
            originalStudentRequest.Status = item.Status;
            originalStudentRequest.Student = item.Student;
            originalStudentRequest.StudentId = item.StudentId;
            originalStudentRequest.Updated = item.Updated;

            _context.SaveChanges();
        }
    }
}