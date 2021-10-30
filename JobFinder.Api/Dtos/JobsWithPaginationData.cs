using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Api.Dtos
{
    public class JobsWithPaginationData
    {
        public ICollection<JobWithOrgDto> Jobs { get; set; }
        public PaginationDto Pagination { get; set; }
    }
}