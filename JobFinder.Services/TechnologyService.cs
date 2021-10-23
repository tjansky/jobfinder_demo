using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core;
using JobFinder.Core.Models;
using JobFinder.Core.Services;

namespace JobFinder.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IUnitOfWork unitOfWork;
        public TechnologyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Technology>> GetAll()
        {
            return await unitOfWork.Technologies.GetAllAsync();
        }
    }
}