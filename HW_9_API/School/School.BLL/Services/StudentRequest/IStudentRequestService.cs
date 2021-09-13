using School.BLL.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Services.StudentRequest
{
    interface IStudentRequestService : IEntityService<Models.StudentRequest>
    {
        IEnumerable<Models.StudentRequest> GetOpenRequestsByCourse(int courseId);
        int GetOpenRequestsCountByCourse(int courseId);
        IEnumerable<Models.Student> GetStudentsByCourse(int courseId);
        IEnumerable<Models.StudentRequest> GetAllOpen();
    }
}
