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
    public class JobController : ControllerBase
    {
        private readonly IJobService jobService;
        private readonly IMapper mapper;

        public JobController(IJobService jobService, IMapper mapper)
        {
            this.jobService = jobService;
            this.mapper = mapper;
        }

        // GetAll + (pagination, org, tech)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDto>>> Get()
        {
            IEnumerable<Job> jobs = await jobService.GetAllWithOrg();

            IEnumerable<JobDto> jobsDto = mapper.Map<IEnumerable<Job>, IEnumerable<JobDto>>(jobs);
            
            return Ok(jobsDto);
        }


        // GetByIdWith + (org, tech, req, res, bon)
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<JobWithAllDto>>> GetById(int id)
        {
            Job job = await jobService.GetByIdWithAll(id);

            var detailedJobDto = mapper.Map<Job, JobWithAllDto>(job);
            
            return Ok(detailedJobDto);
        }


        // DeleteById


        // SetInactiveByID


        // UpdateById (this is where will be requirements updated/added/deleted and what tech and empl type is job)


    }
}