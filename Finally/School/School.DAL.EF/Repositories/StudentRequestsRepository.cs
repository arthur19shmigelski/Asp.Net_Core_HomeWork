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
    public class StudentRequestsRepository : IRepository<StudentRequest>
    {
        private readonly AcademyContext _context;

        public StudentRequestsRepository(AcademyContext context)
        {
            _context = context;
        }

        public async Task Create(StudentRequest item)
        {
            _context.StudentRequests.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            StudentRequest item = await _context.StudentRequests.FindAsync(id);
            _context.StudentRequests.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudentRequest>> Find(Func<StudentRequest, bool> predicate)
        {
            return await _context.StudentRequests
                            .Where(predicate)
                            .AsQueryable()
                            .ToListAsync();
        }

        public async Task<IEnumerable<StudentRequest>> GetAll()
        {
            return await _context.StudentRequests
                .Include(r => r.Student)
                .Include(r => r.Course)
                .ToListAsync();
        }

        public async Task<StudentRequest> GetById(int id)
        {
            return await _context.StudentRequests.FindAsync(id);
        }

        public async Task Update(StudentRequest item)
        {
            var originalStudentRequest = await _context.StudentRequests.FindAsync(item.Id);

            originalStudentRequest.Comments = item.Comments;
            originalStudentRequest.Course = item.Course;
            originalStudentRequest.CourseId = item.CourseId;
            originalStudentRequest.Created = item.Created;
            originalStudentRequest.Status = item.Status;
            originalStudentRequest.Student = item.Student;
            originalStudentRequest.StudentId = item.StudentId;
            originalStudentRequest.Updated = item.Updated;

            await _context.SaveChangesAsync();
        }
    }
}