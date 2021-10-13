using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;
using JobFinder.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JobFinder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IJobService jobService;

        public WeatherForecastController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var xd = await jobService.GetAllWithOrg();
            
            return Ok(xd.Select(x => x.Name));
        }
    }
}
