using School.BLL.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.StudentRequest
{
    public interface IStudentRequestService : IEntityService<Models.StudentRequest>
    {
        Task<IEnumerable<Models.StudentRequest>> GetOpenRequestsByCourse(int courseId);
        Task<int> GetOpenRequestsCountByCourse(int courseId);
        Task<IEnumerable<Models.Student>> GetStudentsByCourse(int courseId);
        Task<IEnumerable<Models.StudentRequest>> GetAllOpen();
    }
}
