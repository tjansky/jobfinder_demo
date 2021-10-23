using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;
using JobFinder.Core.Models.Settings;

namespace JobFinder.Core.Repositories
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<IEnumerable<Job>> GetAllWithOrgAsync();
        Task<List<Job>> GetAllWithOrgAndFiltersAsync(JobFilter filter);
        Task<Job> GetByIdWithAllAsync(int id);
    }
}