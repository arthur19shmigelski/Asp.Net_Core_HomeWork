using School.BLL.Models.Enum;
using School.BLL.Repository;
using School.DAL.Interfaces;
using System;
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

        public async Task<IEnumerable<Models.Student>> DisplayingIndex(EnumPageActions action, string searchString, EnumSearchParameters searchParametr, int take, int skip = 0)
        {
            take = (take == 0) ? 10 : take;
            if (!String.IsNullOrEmpty(searchString))
            {
                return await SearchAllAsync(searchString, searchParametr, action, take, skip);
            }
            return await GetAllTakeSkipAsync(take, action, skip);
        }

        public async Task<IEnumerable<Models.Student>> GetAllTakeSkipAsync(int take, EnumPageActions action, int skip = 0)
        {
            return await _repository.GetAllTakeSkipAsync(take, action, skip);
        }

        public async Task<IEnumerable<Models.Student>> SearchAllAsync(string searchString, EnumSearchParameters searchParametr, EnumPageActions action, int take, int skip = 0)
        {
            return await _repository.SearchAllAsync(searchString, searchParametr, action, take, skip);
        }
    }
}