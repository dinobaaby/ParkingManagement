

namespace ParkingManagement.Constracts.Authentication
{
    public class AssignRoleClaimRequest
    {
        public string RoleId { get; set; } = null!;
        public string ClaimType { get; set; } = null!;
        public string ClaimValue { get; set;} = null!;
    }
}
