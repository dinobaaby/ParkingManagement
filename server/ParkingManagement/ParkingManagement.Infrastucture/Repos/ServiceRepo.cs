

using Microsoft.EntityFrameworkCore;
using ParkingManagement.Application.Services;
using ParkingManagement.Infrastucture.Data;
using System.Linq.Expressions;

namespace ParkingManagement.Infrastucture.Repos
{
    public class ServiceRepo<T, E> : IServiceRepo<T, E> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> entities;

        public ServiceRepo(ApplicationDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public async Task<T> CreateAsync(T model)
        {
            if(model is null)
            {
                throw new ArgumentNullException("model");
            }
            await entities.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<T> DeleteAsync(T model)
        {
            if(model is null)
            {
                throw new ArgumentException("model can be not null");
            }
            entities.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if(entities is null)
            {
                throw new InvalidOperationException("There is no corresponding table");
            }

            return await entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(E id)
        {
            if(id is null)
            {
                throw new ArgumentException("Invalid id", nameof(id));
            }
            return await entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetByNameAsync(Expression<Func<T, bool>> expression)
        {
            return  await entities.Where(expression).ToListAsync();
        }

        public IQueryable<T> SearchAsync(Expression<Func<T, bool>> expression)
        {
            return entities.Where(expression);
        }

        public async Task<T> UpdateAsync(T model)
        {
            if(model is null)
            {
                throw new ArgumentException("Model can be not null");
            }
            entities.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
