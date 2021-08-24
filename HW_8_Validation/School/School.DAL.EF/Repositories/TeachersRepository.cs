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

        public void Delete(Teacher item)
        {
            _context.Teachers.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<Teacher> Find(Func<Teacher, bool> predicate)
        {
            return _context.Teachers.Where(predicate).ToList();
        }

        public Teacher Get(int id) => _context.Teachers.Find(id);

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public void Update(Teacher item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
