

using Microsoft.AspNetCore.Identity;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.DTOs.Authentication;
using ParkingManagement.Application.DTOs.Role;

namespace ParkingManagement.Application.Services
{
    public interface IRoleService
    {
        Task<ServerResponse> GetAllRolesAsync();
        Task<ServerResponse> CreateRoleAsync(string roleName);
        Task<ServerResponse> UpdateRoleAsync(IdentityRole role);
        Task<ServerResponse> DeleteRoleAsync(string roleName);
        Task<ServerResponse> GetTotalUserRoleAsync();
        Task<ServerResponse> GetUserByRoleAsync(string roleName, int pageIndex, int pageSize);

    }
}
