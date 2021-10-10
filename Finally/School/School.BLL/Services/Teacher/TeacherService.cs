using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Teacher
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Core.Models.Teacher> _repository;

        public TeacherService(IRepository<Core.Models.Teacher> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Core.Models.Teacher>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Core.Models.Teacher> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(Core.Models.Teacher teacher)
        {
            await _repository.Create(teacher);
        }

        public async Task Update(Core.Models.Teacher teacher)
        {
            await _repository.Update(teacher);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}