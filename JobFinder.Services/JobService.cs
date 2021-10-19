using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core;
using JobFinder.Core.Models;
using JobFinder.Core.Services;

namespace JobFinder.Services
{
    public class JobService : IJobService
    {

        private readonly IUnitOfWork _unitOfWork;
        public JobService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Job>> GetAllWithOrg()
        {
            return await _unitOfWork.Jobs.GetAllWithOrgAsync();
        }

        public async Task<Job> GetByIdWithAll(int id)
        {
            return await _unitOfWork.Jobs.GetByIdWithAllAsync(id);
        }

        public async Task<Job> GetById(int id)
        {
            return await _unitOfWork.Jobs.GetByIdAsync(id);
        }

        public async Task Delete(Job job)
        {
            _unitOfWork.Jobs.Remove(job);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Job> ChangeActivity(Job job, bool activity)
        {
            job.Active = activity;
            await _unitOfWork.CommitAsync();
            
            return job;
        }

    }
}