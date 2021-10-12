using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;
using JobFinder.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Data
{
    public class JobFinderDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ReqResBon> ReqResBons { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<ExperienceLevel> ExperienceLevels { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }

        public JobFinderDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new OrganizationConfiguration());

            builder
                .ApplyConfiguration(new JobConfiguration());

            builder
                .ApplyConfiguration(new UserConfiguration());

            builder
                .ApplyConfiguration(new ReqResBonConfiguration());
        }

    }
}