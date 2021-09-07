using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.DAL.EF.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL.EF.Repositories
{
    public class StudentsRepository : BaseRepository<Student>
    {
        private readonly AcademyContext _context;

        public StudentsRepository(AcademyContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Student> GetAll()
        {
                return _context.Students.AsNoTracking()
                .Include(s => s.Group)
                .ToList();
        }

        public override void Update(Student item)
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