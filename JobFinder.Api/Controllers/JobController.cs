using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobFinder.Api.Dtos;
using JobFinder.Core.Models;
using JobFinder.Core.Models.Settings;
using JobFinder.Core.Paging;
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


        [HttpGet("GetAll")]
        public async Task<ActionResult<JobsWithPaginationData>> Test([FromQuery]PagingParameters paging, [FromQuery]JobFilter filter)
        {
            PagedList<Job> pagedJobs = await jobService.GetAllWithOrgFiltersAndPagination(paging, filter);

            ICollection<JobWithOrgDto> jobsDto = mapper.Map<ICollection<Job>, ICollection<JobWithOrgDto>>(pagedJobs);

            PaginationDto pagination = new PaginationDto 
            {
                TotalPages = pagedJobs.TotalPages,
                PageSize = pagedJobs.PageSize,
                CurrentPage = pagedJobs.CurrentPage,
                TotalCount = pagedJobs.TotalCount
            };

            JobsWithPaginationData jobsWithPagination = new JobsWithPaginationData {Jobs = jobsDto, Pagination = pagination}; 

            return Ok(jobsWithPagination);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobWithOrgDto>>> Get()
        {
            IEnumerable<Job> jobs = await jobService.GetAllWithOrg();

            IEnumerable<JobWithOrgDto> jobsDto = mapper.Map<IEnumerable<Job>, IEnumerable<JobWithOrgDto>>(jobs);
            
            return Ok(jobsDto);
        }


        // GetByIdWith + (org, tech, req, res, bon)
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<JobWithAllDto>>> GetById(int id)
        {
            Job job = await jobService.GetByIdWithAll(id);

            if (job == null) 
            {
                return BadRequest("There is no job with id: " + id);
            }

            var detailedJobDto = mapper.Map<Job, JobWithAllDto>(job);
            
            return Ok(detailedJobDto);
        }


        // DeleteById
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            Job job = await jobService.GetById(id);

            if (job == null) 
            {
                return BadRequest("There is no job with id: " + id);
            }

            await jobService.Delete(job);
            
            return Ok("Nothing for now, guess it was deleted");
        }

        // SetInactiveByID 
        // TODO: testirati
        [HttpPost("changeActivity/{id}/{activity}")]
        public async Task<ActionResult<Job>> ChangeActivity(int id, bool activity)
        {
            Job job = await jobService.GetById(id);

            if (job == null) 
            {
                return BadRequest("There is no job with id: " + id);
            }

            return Ok(await jobService.ChangeActivity(job, activity));
        }


        // UpdateById (this is where will be requirements updated/added/deleted and what tech and empl type is job)


        // Create


    }
}