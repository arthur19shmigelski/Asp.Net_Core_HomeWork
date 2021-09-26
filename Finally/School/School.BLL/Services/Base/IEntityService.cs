using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Base
{
    public interface IEntityService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
    }
}