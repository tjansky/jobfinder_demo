using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;

namespace JobFinder.Core.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllWithOrg();
        Task<Job> GetByIdWithAll(int id);
        Task<Job> GetById(int id);
        Task Delete(Job job);
    }
}