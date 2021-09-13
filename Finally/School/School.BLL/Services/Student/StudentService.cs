using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Models.Student> _repository;

        public StudentService(IRepository<Models.Student> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Models.Student>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Models.Student> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(Models.Student student)
        {
            await _repository.Create(student);
        }

        public async Task Update(Models.Student student)
        {
            await _repository.Update(student);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}