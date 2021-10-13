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

        public Task<IEnumerable<Job>> GetAllWithOrg()
        {
            return _unitOfWork.Jobs.GetAllWithOrgAsync();
        }
    }
}