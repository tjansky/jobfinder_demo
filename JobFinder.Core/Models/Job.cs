using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Core.Models
{
    public class Job
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
        public virtual Organization Organization { get; set; }
        public virtual ICollection<User> SavedUsers { get; set; }
    }
}