﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.DAL.EF.Contexts;

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


        public void Delete(int id)
        {
            var entity = _entities.Find(id);
            if (entity != null)
                _entities.Remove(entity);
        }

        public void Delete(TEntity item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _entities.AsEnumerable().Where(predicate).ToList();
        }

        public TEntity Get(int id) => _entities.Find(id);

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
