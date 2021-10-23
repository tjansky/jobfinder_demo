using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;
using JobFinder.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Data.Repositories
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(JobFinderDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Organization>> GetAllWithJobsAsync()
        {
            return await JobFinderDbContext.Organizations.Include(x => x.OrganizationJobs).ToListAsync();
        }

        public async Task<Organization> GetByIdWithJobsAsync(int id)
        {
            return await JobFinderDbContext.Organizations.Include(x => x.OrganizationJobs).FirstOrDefaultAsync(x => x.Id == id);
        }

        private JobFinderDbContext JobFinderDbContext
        {
            get { return Context as JobFinderDbContext; }
        }

    }
}