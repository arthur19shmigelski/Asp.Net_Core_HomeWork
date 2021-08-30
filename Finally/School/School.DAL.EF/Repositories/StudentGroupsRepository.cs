using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.DAL.EF.Contexts;
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

        public void Create(StudentGroup item)
        {
            _context.StudentGroups.Add(item);
            _context.SaveChanges();
        }

        public void Delete(StudentGroup item)
        {
            
            if (item != null)
                _context.StudentGroups.Remove(item);
        }

        public IEnumerable<StudentGroup> Find(Func<StudentGroup, bool> predicate)
        {
            return _context.StudentGroups.Where(predicate).ToList();
        }

        public StudentGroup Get(int id) => _context.StudentGroups.Include(g => g.Students).First(g => g.Id == id);

        public IEnumerable<StudentGroup> GetAll()
        {
            return _context.StudentGroups.Include(g => g.Teacher).ToList();
        }

        public void Update(StudentGroup item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
