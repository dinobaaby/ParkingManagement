

namespace ParkingManagement.Constracts.Authentication
{
    public class ChangePasswordRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string ConfirmNewPassword { get; set; } = null!;
    }
}
