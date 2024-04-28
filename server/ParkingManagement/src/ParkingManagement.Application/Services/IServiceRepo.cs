

using System.Linq.Expressions;

namespace ParkingManagement.Application.Services
{
    public interface IServiceRepo<T, E> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(E id);
        Task<IEnumerable<T>> GetByUserNameAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> SearchAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<T> DeleteAsync(T model);
    }
}
