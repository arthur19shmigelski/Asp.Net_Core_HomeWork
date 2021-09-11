using School.DAL.Interfaces;
using System.Collections.Generic;

namespace School.BLL.Services.Teacher
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Models.Teacher> _repository;

        public TeacherService(IRepository<Models.Teacher> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Models.Teacher> GetAll()
        {
            return _repository.GetAll();
        }

        public Models.Teacher GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Create(Models.Teacher teacher)
        {
            _repository.Create(teacher);
        }

        public void Update(Models.Teacher teacher)
        {
            _repository.Update(teacher);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}