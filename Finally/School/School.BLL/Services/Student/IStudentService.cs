using School.BLL.Services.Base;
using School.Core.Models.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Student
{
    public interface IStudentService : IEntityService<Core.Models.Student>
    {

        Task<IEnumerable<Core.Models.Student>> Search(string search);
    }
}
