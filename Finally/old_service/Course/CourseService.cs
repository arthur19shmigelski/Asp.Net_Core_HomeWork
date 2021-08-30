using School.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Services.Course
{
    class CourseService : ICourseService
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
            return _repository.Get(id);
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

        public void Delete(Models.Course course)
        {
            throw new System.NotImplementedException();
        }
    }
}
