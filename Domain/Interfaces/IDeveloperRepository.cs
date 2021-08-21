using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDeveloperRepository : IGenericRepository<Developer>
    {
        Task<IQueryable<Developer>> GetPopularDevelopersAsync(int count);
    }
}