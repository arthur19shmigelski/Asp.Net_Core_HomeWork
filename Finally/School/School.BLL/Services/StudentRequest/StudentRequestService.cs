using School.BLL.Models.Enum;
using School.BLL.Services.Base;
using School.DAL;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Services.StudentRequest
{
   public class StudentRequestService : BaseEntityService<Models.StudentRequest>, IStudentRequestService
    {
        private readonly IRepository<Models.StudentRequest> _repository;

        public StudentRequestService(IRepository<Models.StudentRequest> repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Models.StudentRequest> GetAllOpen()
        {
            return _repository.GetAll().Where(r => r.Status == RequestStatus.Open);
        }

        public IEnumerable<Models.StudentRequest> GetOpenRequestsByCourse(int courseId)
        {
            return _repository.GetAll().Where(r => r.CourseId == courseId && r.Status == RequestStatus.Open);
        }

        public int GetOpenRequestsCountByCourse(int courseId)
        {
            return _repository.Find(r => r.CourseId == courseId && r.Status == RequestStatus.Open).Count();
        }

        public IEnumerable<Models.Student> GetStudentsByCourse(int courseId)
        {
            return _repository.GetAll().Where(r => r.CourseId == courseId).Select(r => r.Student).Distinct();
        }


    }
}
