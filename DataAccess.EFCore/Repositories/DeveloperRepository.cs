using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore.Repositories
{
    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IQueryable<Developer>> GetPopularDevelopersAsync(int count)
        {
            var list = await _context.Developers.OrderByDescending(d => d.Followers).Take(count).ToListAsync();
            return list.AsQueryable();
        }
    }
}