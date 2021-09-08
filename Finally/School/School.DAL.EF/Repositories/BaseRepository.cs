using School.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.EF.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AcademyContext _context;
        private readonly DbSet<TEntity> _entities;


        public BaseRepository(AcademyContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }


        public void Create(TEntity item)
        {
            _context.Entry(item).State = EntityState.Added;

            _context.SaveChanges();
        }

        
        public virtual void Delete(int id)
        {
            
            var entity = _entities.Find(id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();

            //if (entity != null)
            //{
            //    _entities.Remove(entity);

            //    _context.SaveChanges();
            //}
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _entities.AsEnumerable().Where(predicate).ToList();
        }

        public virtual TEntity Get(int id) => _entities.Find(id);

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public virtual void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
