using School.BLL.Models.Enum;
using School.BLL.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Student
{
    public interface IStudentService : IEntityService<Models.Student>
    {
        Task<IEnumerable<Models.Student>> SearchAllAsync(string searchString, EnumSearchParameters searchParametr, EnumPageActions action, int take, int skip = 0);
        Task<IEnumerable<Models.Student>> GetAllTakeSkipAsync(int take, EnumPageActions action, int skip = 0);
        Task<IEnumerable<Models.Student>> DisplayingIndex(EnumPageActions action, string searchString, EnumSearchParameters searchParametr, int take, int skip = 0);
    }
}
