using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Core.Models.Settings
{
    public class JobFilter
    {
        public bool Remote { get; set; }
        public bool Equity { get; set; }
        public List<int> ExpLevelIds { get; set; } = new List<int>();
        public List<int> TechIds { get; set; } = new List<int>();
        public List<int> OrgIds { get; set; } = new List<int>();
        public List<int> EmpTypeIds { get; set; } = new List<int>();
        public int MinSalary { get; set; }
        public int SortType { get; set; }
    }
}