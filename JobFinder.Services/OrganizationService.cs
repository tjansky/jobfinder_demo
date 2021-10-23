using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core;
using JobFinder.Core.Models;
using JobFinder.Core.Services;

namespace JobFinder.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrganizationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Organization>> GetAll()
        {
            return await unitOfWork.Organizations.GetAllAsync();
        }

        public async Task<IEnumerable<Organization>> GetAllWithJobs()
        {
            return await unitOfWork.Organizations.GetAllWithJobsAsync();
        }

        public async Task<Organization> GetByIdWithJobs(int id)
        {
            return await unitOfWork.Organizations.GetByIdWithJobsAsync(id);
        }
    }
}