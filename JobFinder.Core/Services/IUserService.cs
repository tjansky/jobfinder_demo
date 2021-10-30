using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Models;

namespace JobFinder.Core.Services
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<User> FindByEmail(string email);
    }
}