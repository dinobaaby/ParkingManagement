

using ParkingManagement.Application.DTOs;
using ParkingManagement.Constracts.Authentication;

namespace ParkingManagement.Application.Services
{
    public interface IAuthenticationService
    {
        Task<ServerResponse> RegisterAsync(RegisterRequest model);

        Task<ServerResponse> LoginAsync(LoginRequest model);

        Task<ServerResponse> GetAllUsersAsync();

        Task<ServerResponse> AssignRoleAsync(string email, string rolename);

        Task<ServerResponse> ForgotPasswordAsync(string email);

        Task<ServerResponse> ConfirmEmailAsync(string email, string token);

        Task<ServerResponse> ResetPasswordAsync(ResetPasswordRequest model);

        Task<ServerResponse> ChangePasswordAsync(ChangePasswordRequest model);

        Task<ServerResponse> AssigRoleClaimAsync();
        Task<ServerResponse> DeleteUserAsync(string email);
    }
}
