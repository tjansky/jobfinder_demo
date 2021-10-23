using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;
using JobFinder.Core.Models.Settings;
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

        public async Task<List<Job>> GetAllWithOrgAndFiltersAsync(JobFilter filter)
        {
            var query = JobFinderDbContext.Jobs.Include(x => x.Organization).Where(x => x.IsRemote == filter.Remote && x.EquityAvaliable == filter.Equity);
            
            // handle filters
            if(filter.ExpLevelIds.Count() > 0)
            {
                // every job that has at least one experience level that is in filter
                query = query.Where(x => x.ExperienceLevels.Any(y => filter.ExpLevelIds.Contains(y.Id)));
            }

            if(filter.TechIds.Count() > 0)
            {
                // every job that has at least one tech that is in filter
                query = query.Where(x => x.Technologies.Any(y => filter.TechIds.Contains(y.Id)));
            }

            if(filter.EmpTypeIds.Count() > 0)
            {
                // every job that has at least one employment type that is in filter
                query = query.Where(x => x.EmploymentTypes.Any(y => filter.EmpTypeIds.Contains(y.Id)));
            }

            if(filter.OrgIds.Count() > 0)
            {
                // every job that has one of organizations in filter
                query = query.Where(x => filter.OrgIds.Contains(x.OrganizationId));
            }

        
            var jobs = await query.ToListAsync();

            return jobs;
        }

        private JobFinderDbContext JobFinderDbContext
        {
            get { return Context as JobFinderDbContext; }
        }
    }
}