
using ParkingManagement.Application.DTOs.Authentication;

namespace ParkingManagement.Application.DTOs.Role
{
    public class UserRoleResponse
    {
        public RoleResponse RoleDetails { get; set; } = null!;
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
