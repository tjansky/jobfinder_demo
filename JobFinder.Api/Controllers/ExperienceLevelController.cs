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
    public class ExperienceLevelController : ControllerBase
    {
        private readonly IExperienceLevelService experienceLevelService;
        private readonly IMapper mapper;

        public ExperienceLevelController(IExperienceLevelService experienceLevelService, IMapper mapper)
        {
            this.experienceLevelService = experienceLevelService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienceLevelDto>>> GetAllExperienceLevels()
        {
            var experienceLevels = await experienceLevelService.GetAll();

            var experienceLevelsDto = mapper.Map<IEnumerable<ExperienceLevel>, IEnumerable<ExperienceLevelDto>>(experienceLevels);

            return Ok(experienceLevelsDto);
        }

        
    }
}