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

        public async Task<IEnumerable<Models.StudentRequest>> GetAllOpen()
        {
            var allRequests =  await _repository.GetAll();
            return allRequests.Where(r => r.Status == RequestStatus.Open);
        }

        public async Task<IEnumerable<Models.StudentRequest>> GetOpenRequestsByCourse(int courseId)
        {
            var allRequests = await _repository.GetAll();
            return allRequests.Where(r => r.CourseId == courseId && r.Status == RequestStatus.Open).ToList();
        }

        public async Task<int> GetOpenRequestsCountByCourse(int courseId)
        {
            var findAll = await _repository.Find(r => r.CourseId == courseId && r.Status == RequestStatus.Open);
            return  findAll.ToList().Count();
        }

        public async Task<IEnumerable<Models.Student>> GetStudentsByCourse(int courseId)
        {
            var allRequests = await _repository.GetAll();

            return allRequests.Where(r => r.CourseId == courseId).Select(r => r.Student).Distinct();
        }
    }
}
