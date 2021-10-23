using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;

namespace JobFinder.Core.Repositories
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        Task<IEnumerable<Organization>> GetAllWithJobsAsync();
        Task<Organization> GetByIdWithJobsAsync(int id);
    }
}