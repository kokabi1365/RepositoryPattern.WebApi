using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDeveloperRepository Developer { get; }
        IProjectRepository Projects { get; }
        Task<int> CompleteAsync();
    }
}