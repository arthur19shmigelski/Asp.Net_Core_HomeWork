using School.Core.Models;
using School.Core.Models.Pages;
using System.Threading.Tasks;

namespace School.DAL.Interfaces
{
    public interface ITopicRepository : IRepository<Topic>
    {
        public Task<PageList<Topic>> GetByPagesAndSorted(PaginationOptions options, string sortOrder);
    }
}
