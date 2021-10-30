using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core;
using JobFinder.Core.Models;
using JobFinder.Core.Services;

namespace JobFinder.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> FindByEmail(string email)
        {
            User user = await unitOfWork.Users.GetByEmailAsync(email);
            return user;
        }

        public async Task<User> Register(User user)
        {
            await unitOfWork.Users.AddAsync(user);
            await unitOfWork.CommitAsync();
            return user;
        }
    }
}