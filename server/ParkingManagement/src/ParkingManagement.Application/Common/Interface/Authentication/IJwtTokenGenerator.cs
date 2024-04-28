
using ParkingManagement.Domain.Entities.Authetication;

namespace ParkingManagement.Application.Common.Interface.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> roles);

        string GenerateTokenByUserId(string userId);

        string GenerateRefreshToken();
    }
}
