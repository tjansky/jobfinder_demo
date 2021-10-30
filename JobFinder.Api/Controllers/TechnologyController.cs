using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobFinder.Api.Dtos;
using JobFinder.Core.Models;
using JobFinder.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService technologyService;
        private readonly IMapper mapper;

        public TechnologyController(ITechnologyService technologyService, IMapper mapper)
        {
            this.technologyService = technologyService;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnologyDto>>> GetAllTechnologies()
        {
            var technologies = await technologyService.GetAll();

            var technologiesDto = mapper.Map<IEnumerable<Technology>, IEnumerable<TechnologyDto>>(technologies);

            return Ok(technologiesDto);
        }

    }
}