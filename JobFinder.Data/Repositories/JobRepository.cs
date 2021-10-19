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

        public async Task<Job> GetByIdWithAllAsync(int id)
        {
            return await JobFinderDbContext.Jobs
                        .Include(x => x.Technologies)
                        .Include(x => x.Organization)
                        .Include(x => x.ExperienceLevels)
                        .Include(x => x.EmploymentTypes)
                        .Include(x => x.ReqResBons)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        private JobFinderDbContext JobFinderDbContext
        {
            get { return Context as JobFinderDbContext; }
        }
    }
}