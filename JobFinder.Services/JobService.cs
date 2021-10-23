using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core;
using JobFinder.Core.Models;
using JobFinder.Core.Models.Settings;
using JobFinder.Core.Services;

namespace JobFinder.Services
{
    public class JobService : IJobService
    {
        private readonly int sortByName = 1;
        private readonly int sortByNewest = 2;
        private readonly int sortBySalary = 3;

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

        public async Task<List<Job>> GetAllWithOrgAndFiltersAsync(JobFilter filter)
        {
            var jobs = await _unitOfWork.Jobs.GetAllWithOrgAndFiltersAsync(filter);

            // handle sort
            if(filter.SortType != 0)
            {   
                // sort by name
                if(filter.SortType == sortByName)
                {
                    jobs = jobs.OrderByDescending(x => x.Name).ToList();
                }
                // sort by newest
                else if(filter.SortType == sortByNewest)
                {
                    jobs = jobs.OrderByDescending(x => x.PostDate).ToList();
                }
                // sort by salary
                else if(filter.SortType == sortBySalary)
                {
                    jobs = jobs.OrderByDescending(x => x.Salary).ToList();
                }
            }
            
            return jobs;
        }
    }
}