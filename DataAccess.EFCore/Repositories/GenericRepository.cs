using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var list = await _context.Set<T>().ToListAsync();
            return list.AsQueryable();
        }

        public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            var list = await _context.Set<T>().Where(expression).ToListAsync();
            return list.AsQueryable();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IQueryable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IQueryable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}