using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.DAL.EF.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL.EF.Repositories
{
    public class StudentRequestsRepository : BaseRepository<StudentRequest>
    {
        private readonly AcademyContext _context;

        public StudentRequestsRepository(AcademyContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<StudentRequest> GetAll()
        {
            return _context.StudentRequests
                .Include(r => r.Student)
                .Include(r => r.Course)
                .ToList();
        }

        public override void Update(StudentRequest item)
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