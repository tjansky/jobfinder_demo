using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Api.Dtos
{
    public class OrganizationWithJobsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HomePageUrl { get; set; }
        public string PictureUrl { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<JobDto> OrganizationJobs { get; set; }
    }
}