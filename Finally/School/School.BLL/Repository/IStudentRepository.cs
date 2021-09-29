using School.Core.Models;
using School.Core.Models.Enum;
using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> Search(string searchStringFirstName, string searchStringLastName, int skip = 0, int? take = null, bool? orderAsc = null);
        Task<IEnumerable<Student>> GetAllTakeSkipAsync(int take, EnumPageActions action, int skip);
        Task<IEnumerable<Student>> SearchAllAsync(string searchString, EnumSearchParameters searchParametr, EnumPageActions action, int take, int skip);
    }
}
