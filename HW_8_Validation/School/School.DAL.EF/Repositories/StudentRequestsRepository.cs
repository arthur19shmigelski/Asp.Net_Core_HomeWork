using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.DAL.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
