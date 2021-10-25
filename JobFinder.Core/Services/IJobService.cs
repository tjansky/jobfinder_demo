using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;
using JobFinder.Core.Models.Settings;
using JobFinder.Core.Paging;

namespace JobFinder.Core.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllWithOrg();
        // Task<List<Job>> GetAllWithOrgAndFiltersAsync(JobFilter filter);
        Task<PagedList<Job>> GetAllWithOrgFiltersAndPagination(PagingParameters pagingParameters, JobFilter filter);
        Task<Job> GetByIdWithAll(int id);
        Task<Job> GetById(int id);
        Task Delete(Job job);
        Task<Job> ChangeActivity(Job job, bool activity);
    }
}