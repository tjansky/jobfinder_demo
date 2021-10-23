using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Repositories;

namespace JobFinder.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IJobRepository Jobs { get; }
        IExperienceLevelRepository ExperienceLevels { get; }
        IEmploymentTypeRepository EmploymentTypes { get; }
        ITechnologyRepository Technologies { get; }
        IOrganizationRepository Organizations { get; }
        Task<int> CommitAsync();
    }
}