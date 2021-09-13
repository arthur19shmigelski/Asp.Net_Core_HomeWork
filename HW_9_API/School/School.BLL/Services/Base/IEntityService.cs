using System.Collections.Generic;

namespace School.BLL.Services.Base
{
    public interface IEntityService<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
