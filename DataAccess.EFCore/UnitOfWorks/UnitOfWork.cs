using System.Threading.Tasks;
using DataAccess.EFCore.Repositories;
using Domain.Interfaces;

namespace DataAccess.EFCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Developer = new DeveloperRepository(_context);
            Projects = new ProjectRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IDeveloperRepository Developer { get; private set; }
        public IProjectRepository Projects { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}