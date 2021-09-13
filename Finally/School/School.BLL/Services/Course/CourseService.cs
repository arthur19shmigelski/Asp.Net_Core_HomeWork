using School.DAL.Interfaces;
using System.Collections.Generic;

namespace School.BLL.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Models.Course> _repository;

        public CourseService(IRepository<Models.Course> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Models.Course> GetAll()
        {
            return _repository.GetAll();
        }

        public Models.Course GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Create(Models.Course course)
        {
            course.Topic = null;
            _repository.Create(course);
        }

        public void Update(Models.Course course)
        {
            _repository.Update(course);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}