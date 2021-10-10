using School.Core.Models;

namespace School.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICourseRepository Courses { get; }
    }
}
