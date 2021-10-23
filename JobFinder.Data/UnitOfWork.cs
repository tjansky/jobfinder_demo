using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core;
using JobFinder.Core.Repositories;
using JobFinder.Data.Repositories;

namespace JobFinder.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JobFinderDbContext _context;
        private JobRepository _jobRepository;
        private ExperienceLevelRepository _experienceLevelRepository;

        public UnitOfWork(JobFinderDbContext context)
        {
            this._context = context;
        }

        public IJobRepository Jobs => _jobRepository = _jobRepository ?? new JobRepository(_context);
        public IExperienceLevelRepository ExperienceLevels => _experienceLevelRepository ?? new ExperienceLevelRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}