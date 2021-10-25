using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;
using JobFinder.Core.Models.Settings;
using JobFinder.Core.Paging;

namespace JobFinder.Core.Repositories
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<IEnumerable<Job>> GetAllWithOrgAsync();
        Task<List<Job>> GetAllWithOrgAndFiltersAsync(JobFilter filter);
        Task<PagedList<Job>> GetAllWithOrgFiltersAndPaginationAsync(PagingParameters pagingParameters, JobFilter filter);
        Task<Job> GetByIdWithAllAsync(int id);
    }
}