using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Core.Repositories;

namespace JobFinder.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IJobRepository Jobs { get; }
        Task<int> CommitAsync();
    }
}