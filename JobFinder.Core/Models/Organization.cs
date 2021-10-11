using System.Collections.Generic;

namespace JobFinder.Core.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HomePageUrl { get; set; }
        public string PictureUrl { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<Job> OrganizationJobs { get; set; }
    }
}