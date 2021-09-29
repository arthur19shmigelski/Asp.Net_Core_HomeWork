using Microsoft.EntityFrameworkCore;
using School.BLL.Repository;
using School.Core.Models;
using School.Core.Models.Enum;
using School.DAL.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace School.DAL.EF.Repositories
{
    public class StudentsRepository : IStudentRepository
    {
        private readonly AcademyContext _context;
        private readonly int skipById = 20;
        private readonly int takeByCount = 10;

        public StudentsRepository(AcademyContext context)
        {
            _context = context;
        }

        public async Task Create(Student item)
        {
            await _context.Students.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _context.Students.FindAsync(id);
            _context.Students.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> Find(Func<Student, bool> predicate)
        {
            return await _context.Students
                                        .Where(predicate)
                                        .AsQueryable()
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.AsNoTracking()
            .Include(s => s.Group)
            .ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> Search(string searchStringFirstName, 
            string searchStringLastName, 
            int skip = 0, 
            int? take = null, 
            bool? orderAsc = null)
        {
            IQueryable<Student> result = ApplyOrder(orderAsc);
                
            result = ApplyWhere(result, searchStringFirstName, searchStringLastName);

            result = result.Skip(skip);

            if (take.HasValue)
                result = result.Take(take.Value);

            return await result.ToListAsync();
        }

        private IQueryable<Student> ApplyOrder(bool? orderAsc)
        {
            var result = _context.Students.AsQueryable();

            if (!orderAsc.HasValue)
                return result;

            return orderAsc.Value ? result.OrderBy(f => f.FirstName) : result.OrderByDescending(f => f.FirstName);
        }

        private IQueryable<Student> ApplyWhere(IQueryable<Student> students, string searchStringFirstName, string searchStringLastName)
        {
            IQueryable<Student> result = students.Include(g=>g.Group).ThenInclude(c=>c.Course);

            if (!string.IsNullOrWhiteSpace(searchStringFirstName))
                result = result.Where(s => s.FirstName.Contains(searchStringFirstName, System.StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(searchStringLastName))
                result = result.Where(s => s.LastName.Contains(searchStringLastName, System.StringComparison.OrdinalIgnoreCase));

            return result;
        }

        public async Task Update(Student item)
        {
            var originalStudent = await _context.Students.FindAsync(item.Id);

            originalStudent.Age = item.Age;
            originalStudent.Email = item.Email;
            originalStudent.FirstName = item.FirstName;
            originalStudent.LastName = item.LastName;
            originalStudent.Group = item.Group;
            originalStudent.GroupId = item.GroupId;
            originalStudent.Phone = item.Phone;
            originalStudent.Type = item.Type;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> SearchAllAsync(string searchString, EnumSearchParameters searchParametr, EnumPageActions action, int take, int skip = 0)
        {
            if (string.IsNullOrEmpty(searchString) || searchParametr == EnumSearchParameters.none)
                return null;
            if (action == EnumPageActions.add)
                return await _context.Students.AsQueryable().Include(s => s.Group).ThenInclude(g => g.Course)
                .Where($"{searchParametr.ToString().Replace('_', '.')}.Contains(@0)", searchString).Skip(skip).Take(take + takeByCount).ToListAsync();

            return await _context.Students.AsQueryable().Include(s => s.Group).ThenInclude(g => g.Course)
             .Where($"{searchParametr.ToString().Replace('_', '.')}.Contains(@0)", searchString).Skip(skip).Take(take).ToListAsync();
        }
        public async Task<IEnumerable<Student>> GetAllTakeSkipAsync(int take, EnumPageActions action, int skip = 0)
        {
            if (action == EnumPageActions.next)
                return await _context.Students.AsQueryable().Include(s => s.Group).ThenInclude(g => g.Course).Skip(skip).Take(take).ToListAsync();

            if (action == EnumPageActions.back)
            {
                skip = (skip < skipById) ? 20 : skip;
                return await _context.Students.AsQueryable().Include(s => s.Group).ThenInclude(g => g.Course).Skip(skip - skipById).Take(take).ToListAsync();
            }

            return await _context.Students.AsQueryable().Include(s => s.Group).ThenInclude(g => g.Course).Skip(skip).Take(take).ToListAsync();
        }
    }
}