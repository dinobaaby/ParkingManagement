
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Services
{
    public interface IAreaService
    {
        Task<IEnumerable<Area>> GetListAsync();

        Task<Area> GetByIdAsync(int id);
        Task<IEnumerable<Area>> GetByNameAsync(string name);

        Task<Area> CreateAsync(Area area);
        Task<bool> UpdateAsync(Area area);
        Task<bool> DeleteAsync(int id);
    }
}
