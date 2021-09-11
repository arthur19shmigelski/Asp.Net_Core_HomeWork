using School.BLL.Models.Enum;
using School.BLL.Services.Student;
using School.BLL.Services.StudentRequest;
using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace School.BLL.Services.StudentGroup
{
    public class StudentGroupService : IStudentGroupService
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
            return _repository.GetById(id);
        }

        public void Create(Models.StudentGroup entity)
        {
            _repository.Create(entity);

            //find all requests related to new group
            var requests = _requestService.GetOpenRequestsByCourse(entity.CourseId).ToList();

            //add students from requests to group
            var studentsToGroup = requests.Select(r => r.Student);
            foreach (var student in studentsToGroup)
            {
                student.GroupId = entity.Id;
                _studentService.Update(student);
            }

            //close requests
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

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}