using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;

namespace JobFinder.Core.Services
{
    public interface IOrganizationService
    {
        Task<IEnumerable<Organization>> GetAll();
        Task<IEnumerable<Organization>> GetAllWithJobs();
        Task<Organization> GetByIdWithJobs(int id);
    }
}