using School.BLL.Models;
using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> Search(string searchStringFirstName, string searchStringLastName, int skip = 0, int? take = null, bool? orderAsc = null);
    }
}
