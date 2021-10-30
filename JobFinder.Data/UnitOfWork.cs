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
        private EmploymentTypeRepository _employmentTypeRepository;
        private TechnologyRepository _technologyRepository;
        private OrganizationRepository _organizationRepository;
        private UserRepository _userRepository;
        public UnitOfWork(JobFinderDbContext context)
        {
            this._context = context;
        }

        public IJobRepository Jobs => _jobRepository = _jobRepository ?? new JobRepository(_context);
        public IExperienceLevelRepository ExperienceLevels => _experienceLevelRepository ?? new ExperienceLevelRepository(_context);
        public IEmploymentTypeRepository EmploymentTypes => _employmentTypeRepository ?? new EmploymentTypeRepository(_context);
        public ITechnologyRepository Technologies => _technologyRepository ?? new TechnologyRepository(_context);
        public IOrganizationRepository Organizations => _organizationRepository ?? new OrganizationRepository(_context);
        public IUserRepository Users => _userRepository ?? new UserRepository(_context);

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