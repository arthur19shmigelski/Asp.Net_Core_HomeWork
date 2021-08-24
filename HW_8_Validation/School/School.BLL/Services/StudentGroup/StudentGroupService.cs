using School.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.BLL.Models;
using School.BLL.Services.Student;
using School.BLL.Services.StudentRequest;
using School.BLL.Models.Enum;

namespace School.BLL.Services.StudentGroup
{
    class StudentGroupService : IStudentGroupService
    {
        private readonly IRepository<Models.StudentGroup> _repository;
        private readonly IStudentRequestService _requestService;
        private readonly IStudentService _studentService;

        public StudentGroupService(IRepository<Models.StudentGroup> repository, IStudentRequestService requestService, IStudentService studentService)
        {
            _repository = repository;
            _requestService = requestService;
            _studentService = studentService;
        }

        public IEnumerable<Models.StudentGroup> GetAll()
        {
            return _repository.GetAll();
        }

        public Models.StudentGroup GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Create(Models.StudentGroup entity)
        {
            _repository.Create(entity);

            //add students from requests to group
            var studentsToGroup = _requestService.GetStudentsByCourse(entity.CourseId);
            foreach (var student in studentsToGroup)
            {
                student.GroupId = entity.Id;
                _studentService.Update(student);
            }
            //close requests
            var requests = _requestService.GetOpenRequestsByCourse(entity.CourseId);
            foreach (var request in requests)
            {
                request.Status = RequestStatus.Closed;
                _requestService.Update(request);
            }
        }

        public void Update(Models.StudentGroup group)
        {
            _repository.Update(group);
        }

        public void Delete(Models.StudentGroup group)
        {
            throw new System.NotImplementedException();
        }
    }
}
