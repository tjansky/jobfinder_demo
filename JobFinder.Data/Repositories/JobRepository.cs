using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;
using JobFinder.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Data.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(JobFinderDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Job>> GetAllWithOrgAsync()
        {
            return await JobFinderDbContext.Jobs.Include(x => x.Organization).ToListAsync();
        }

        private JobFinderDbContext JobFinderDbContext
        {
            get { return Context as JobFinderDbContext; }
        }
    }
}