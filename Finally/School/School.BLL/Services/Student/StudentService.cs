using School.BLL.Repository;
using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.BLL.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
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

        public async Task<IEnumerable<Models.Student>> GetPage(string searchStringInFirstName,
            string searchStringInLastName,
            bool? orderAsc, 
            int pageNumber = 1, 
            int pageSize = 20)
        {
            return await _repository.Search(searchStringInFirstName, searchStringInLastName, (pageNumber - 1) * pageSize, pageSize, orderAsc);
        }
    }
}