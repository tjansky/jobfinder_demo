using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;
using JobFinder.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(JobFinderDbContext context) : base(context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await JobFinderDbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        private JobFinderDbContext JobFinderDbContext
        {
            get { return Context as JobFinderDbContext; }
        }

        
    }
}