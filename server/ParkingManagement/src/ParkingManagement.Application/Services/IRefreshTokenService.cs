

using ParkingManagement.Application.DTOs;
using ParkingManagement.Constracts.Authentication;
using ParkingManagement.Domain.Entities.Authetication;

namespace ParkingManagement.Application.Services
{
    public interface IRefreshTokenService
    {
        Task<ServerResponse> CreateRefreshTokenAsync(RefreshToken model);
        Task<ServerResponse> UpdateRefreshTokenAsync(RefreshToken model);
        Task<ServerResponse> RefreshTokenAsync(RefreshTokenRequest model);
    }
}
