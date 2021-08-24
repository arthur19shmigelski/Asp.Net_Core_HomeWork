using School.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _repository.Get(id);
        }

        public void Create(Models.Teacher teacher)
        {
            _repository.Create(teacher);
        }

        public void Update(Models.Teacher teacher)
        {
            _repository.Update(teacher);
        }

        public void Delete(Models.Teacher teacher)
        {
            _repository.Delete(teacher);
        }
    }
}
