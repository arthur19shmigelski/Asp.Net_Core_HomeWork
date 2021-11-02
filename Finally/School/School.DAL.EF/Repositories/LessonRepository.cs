using Microsoft.EntityFrameworkCore;
using School.Core.Models;
using School.Core.Models.Pages;
using School.DAL.EF.Contexts;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.EF.Repositories
{
    public class LessonRepository : IRepository<Lesson>
    {
        private readonly AcademyContext _context;
        public LessonRepository(AcademyContext context)
        {
            _context = context;
        }
        public async Task Create(Lesson item)
        {
            await _context.Lessons.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = _context.Lessons.FindAsync(id);
            _context.Lessons.Remove(item.Result);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Lesson>> Find(Func<Lesson, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Lesson>> GetAll()
        {
            return await _context.Lessons.Include(x=>x.Group).ToListAsync();
        }

        public async Task<Lesson> GetById(int id)
        {
            return await _context.Lessons.AsNoTracking().Include(g=>g.Group).FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public Task<PageList<Lesson>> GetByPages(PaginationOptions options)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Lesson item)
        {
            _context.Lessons.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
