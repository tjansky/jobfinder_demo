using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Api.Dtos
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRemote { get; set; }
        public bool EquityAvaliable { get; set; }
        public string ApplyUrl { get; set; }
        public bool Active { get; set; }
        public int Salary { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public DateTime PostDate { get; set; }

        public int OrganizationId { get; set; }
        public virtual OrganizationDto Organization { get; set; }
        public virtual ICollection<TechnologyDto> Technologies { get; set; }
        public virtual ICollection<ExperienceLevelDto> ExperienceLevels { get; set; }
        public virtual ICollection<EmploymentTypeDto> EmploymentTypes { get; set; }
    }
}