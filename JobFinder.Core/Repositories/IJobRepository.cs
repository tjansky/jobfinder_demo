using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;

namespace JobFinder.Core.Repositories
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<IEnumerable<Job>> GetAllWithOrgAsync();
        Task<Job> GetByIdWithAllAsync(int id);
    }
}