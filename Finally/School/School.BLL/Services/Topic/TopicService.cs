using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Topic
{
    public class TopicService : ITopicService
    {
        private readonly IRepository<Models.Topic> _repository;

        public TopicService(IRepository<Models.Topic> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Models.Topic>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Models.Topic> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(Models.Topic topic)
        {
            await _repository.Create(topic);
        }

        public async Task Update(Models.Topic topic)
        {
            await _repository.Update(topic);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}