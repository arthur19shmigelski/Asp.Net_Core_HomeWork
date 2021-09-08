using School.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Services.Base
{
    public class BaseEntityService<TEntity> : IEntityService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public BaseEntityService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Create(TEntity entity)
        {
            _repository.Create(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
