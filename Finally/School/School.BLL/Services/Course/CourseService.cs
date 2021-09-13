using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Models.Course> _repository;

        public CourseService(IRepository<Models.Course> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Models.Course>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Models.Course> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(Models.Course course)
        {
            course.Topic = null;
            await _repository.Create(course);
        }

        public async Task Update(Models.Course course)
        {
            await _repository.Update(course);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}