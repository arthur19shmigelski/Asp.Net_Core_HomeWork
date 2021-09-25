using School.BLL.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Student
{
    public interface IStudentService : IEntityService<Models.Student>
    {
        Task<IEnumerable<Models.Student>> GetPage(string searchStringInFirstName, string searchStringInLastName, bool? orderAsc, int pageNumber = 1, int pageSize = 20);
    }
}
