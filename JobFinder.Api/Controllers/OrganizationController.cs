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
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService organizationService;
        private readonly IMapper mapper;

        public OrganizationController(IOrganizationService organizationService, IMapper mapper)
        {
            this.organizationService = organizationService;
            this.mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<OrganizationDto>>> GetAllOrganizations()
        {
            var organizations = await organizationService.GetAll();

            var organizationsDto = mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationDto>>(organizations); 

            return Ok(organizationsDto);
        }

        // Get all organizations with jobs
        [HttpGet("GetAllWIthJobs")]
        public async Task<ActionResult<IEnumerable<OrganizationWithJobsDto>>> GetAllOrganizationsWithJobs()
        {
            var organizations = await organizationService.GetAllWithJobs();

            var organizationsDto = mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationWithJobsDto>>(organizations); 

            return Ok(organizationsDto);
        }


        // Get By Id with jobs
        [HttpGet("GetByIdWIthJobs/{id}")]
        public async Task<ActionResult<OrganizationWithJobsDto>> GetOrganizationByIdWithJobs(int id)
        {
            var organization = await organizationService.GetByIdWithJobs(id);

            var organizationDto = mapper.Map<Organization, OrganizationWithJobsDto>(organization); 

            return Ok(organizationDto);
        }

        // UpdateById


        // DeleteById
    }
}