using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Core.Models
{
    public class ReqResBon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int Type { get; set; }

        public int JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}