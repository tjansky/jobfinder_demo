using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Api.Dtos
{
    public class UserWithTokenDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Role { get; set; }
        public string Token { get; set; }
    }
}