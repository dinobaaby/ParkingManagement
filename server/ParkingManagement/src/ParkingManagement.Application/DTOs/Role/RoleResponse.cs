

namespace ParkingManagement.Application.DTOs.Role
{
    public class RoleResponse
    {
        public string RoleId { get; set; } = null!;
        public string RoleName { get; set; } = null!;

        public int TotalUser {  get; set; }
    }
}
