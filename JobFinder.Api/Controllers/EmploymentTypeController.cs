using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobFinder.Api.Dtos;
using JobFinder.Core.Models;
using JobFinder.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmploymentTypeController : ControllerBase
    {
        private readonly IEmploymentTypeService employmentTypeService;
        private readonly IMapper mapper;

        public EmploymentTypeController(IEmploymentTypeService employmentTypeService, IMapper mapper)
        {
            this.employmentTypeService = employmentTypeService;
            this.mapper = mapper;
        }
        
        // get all Employment Types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmploymentTypeDto>>> GetAllExperienceLevels()
        {
            var employmentTypes = await employmentTypeService.GetAll();

            var employmentTypesDto = mapper.Map<IEnumerable<EmploymentType>, IEnumerable<EmploymentTypeDto>>(employmentTypes);

            return Ok(employmentTypesDto);
        }
    }
}