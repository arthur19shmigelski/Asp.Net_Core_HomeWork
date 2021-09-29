using School.Core.Models;
using System.Threading.Tasks;

namespace School.DAL.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<object> Filter(Core.Models.Filters.CourseFilter filter);
    }
}
