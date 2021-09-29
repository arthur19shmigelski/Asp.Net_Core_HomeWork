using School.BLL.Services.Student;
using School.BLL.Services.StudentRequest;
using School.Core.Models.Enum;
using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.BLL.Services.StudentGroup
{
    public class StudentGroupService : IStudentGroupService
    {
        private readonly IRepository<Core.Models.StudentGroup> _repository;
        private readonly IStudentRequestService _requestService;
        private readonly IStudentService _studentService;

        public StudentGroupService(IRepository<Core.Models.StudentGroup> repository, IStudentRequestService requestService, IStudentService studentService)
        {
            _repository = repository;
            _requestService = requestService;
            _studentService = studentService;
        }

        public async Task<IEnumerable<Core.Models.StudentGroup>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Core.Models.StudentGroup> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(Core.Models.StudentGroup entity)
        {
            await _repository.Create(entity);

            //find all requests related to new group
            var requests = await _requestService.GetOpenRequestsByCourse(entity.CourseId);

            var requestsToList = requests.ToList();
            //add students from requests to group
            var studentsToGroup = requestsToList.Select(r => r.Student);
            foreach (var student in studentsToGroup)
            {
                student.GroupId = entity.Id;
                await _studentService.Update(student);
            }

            //close requests
            foreach (var request in requests)
            {
                request.Status = RequestStatus.Closed;
                await _requestService.Update(request);
            }
        }

        public async Task Update(Core.Models.StudentGroup group)
        {
            await _repository.Update(group);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}