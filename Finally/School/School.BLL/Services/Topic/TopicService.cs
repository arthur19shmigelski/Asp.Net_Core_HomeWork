using School.DAL.Interfaces;
using System.Collections.Generic;

namespace School.BLL.Services.Topic
{
    public class TopicService : ITopicService
    {
        private readonly IRepository<Models.Topic> _repository;

        public TopicService(IRepository<Models.Topic> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Models.Topic> GetAll()
        {
            return _repository.GetAll();
        }

        public Models.Topic GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Create(Models.Topic topic)
        {
            _repository.Create(topic);
        }

        public void Update(Models.Topic topic)
        {
            _repository.Update(topic);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}