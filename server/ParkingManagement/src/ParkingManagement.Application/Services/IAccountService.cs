

using ParkingManagement.Application.DTOs.Accout;
using ParkingManagement.Constracts.Authentication;
using ParkingManagement.Domain.Entities.Authetication;

namespace ParkingManagement.Application.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<ApplicationUser>> GetListAsync();

        Task<ApplicationUser> GetByIdAsync(string id);
        Task<IEnumerable<ApplicationUser>> GetByNameAsync(string name);
        Task<ApplicationUser> CreateAsync(ApplicationUser model);
        Task<bool> UpdateAsync(ApplicationUser model);
        Task<bool> DeleteAsync(string id);

    }
}
