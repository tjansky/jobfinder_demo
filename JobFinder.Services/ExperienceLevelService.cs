using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core;
using JobFinder.Core.Models;
using JobFinder.Core.Services;

namespace JobFinder.Services
{
    public class ExperienceLevelService : IExperienceLevelService
    {
        private readonly IUnitOfWork unitOfWork;

        public ExperienceLevelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ExperienceLevel>> GetAll()
        {
            return await unitOfWork.ExperienceLevels.GetAllAsync();
        }
    }
}