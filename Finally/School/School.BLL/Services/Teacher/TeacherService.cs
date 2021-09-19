using School.DAL.Interfaces;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Models.Teacher>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Models.Teacher> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(Models.Teacher teacher)
        {
            await _repository.Create(teacher);
        }

        public async Task Update(Models.Teacher teacher)
        {
            await _repository.Update(teacher);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}