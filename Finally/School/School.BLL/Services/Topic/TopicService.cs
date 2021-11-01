using School.Core.Models.Pages;
using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Topic
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _repository;

        public TopicService(ITopicRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Core.Models.Topic>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Core.Models.Topic> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(Core.Models.Topic topic)
        {
            await _repository.Create(topic);
        }

        public async Task Update(Core.Models.Topic topic)
        {
            await _repository.Update(topic);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<PageList<Core.Models.Topic>> GetByPages(PaginationOptions options)
        {
            return await _repository.GetByPages(options);
        }

        public async Task<PageList<Core.Models.Topic>> GetByPagesAndSorted(PaginationOptions options, string sortOrder)
        {
            return await _repository.GetByPagesAndSorted(options, sortOrder);
        }
    }
}