using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core;
using JobFinder.Core.Models;
using JobFinder.Core.Services;

namespace JobFinder.Services
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        public EmploymentTypeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmploymentType>> GetAll()
        {
            return await unitOfWork.EmploymentTypes.GetAllAsync();
        }
    }
}