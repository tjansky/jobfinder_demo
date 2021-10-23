using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;
using JobFinder.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Data.Repositories
{
    public class ExperienceLevelRepository : Repository<ExperienceLevel>, IExperienceLevelRepository
    {
        public ExperienceLevelRepository(JobFinderDbContext context) : base(context)
        {
        }

        private JobFinderDbContext JobFinderDbContext
        {
            get { return Context as JobFinderDbContext; }
        }
    }
}