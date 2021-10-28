using School.BLL.Services.Base;
using School.Core.Models.Pages;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Lesson
{
    public class LessonService : IEntityService<Core.Models.Lesson>
    {
        private readonly IRepository<Core.Models.Lesson> _repository;
        public LessonService(IRepository<Core.Models.Lesson> repository)
        {
            _repository = repository;
        }

        public async Task Create(Core.Models.Lesson entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Core.Models.Lesson>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Core.Models.Lesson> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public Task<PageList<Core.Models.Lesson>> GetByPages(PaginationOptions options)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Core.Models.Lesson entity)
        {
            await _repository.Update(entity);
        }
    }
}
