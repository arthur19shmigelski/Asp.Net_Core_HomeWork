using School.BLL.Services.Base;
using School.Core.Models.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Student
{
    public interface IStudentService : IEntityService<Core.Models.Student>
    {
        Task<IEnumerable<Core.Models.Student>> SearchAllAsync(string searchString, EnumSearchParameters searchParametr, EnumPageActions action, int take, int skip = 0);
        Task<IEnumerable<Core.Models.Student>> GetAllTakeSkipAsync(int take, EnumPageActions action, int skip = 0);
        Task<IEnumerable<Core.Models.Student>> DisplayingIndex(EnumPageActions action, string searchString, EnumSearchParameters searchParametr, int take, int skip = 0);
    }
}
