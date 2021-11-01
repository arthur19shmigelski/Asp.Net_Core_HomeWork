using School.BLL.Services.Base;
using School.Core.Models.Pages;
using System.Threading.Tasks;

namespace School.BLL.Services.Topic
{
    public interface ITopicService : IEntityService<Core.Models.Topic>
    {
        public Task<PageList<Core.Models.Topic>> GetByPagesAndSorted(PaginationOptions options, string sortOrder);
    }
}