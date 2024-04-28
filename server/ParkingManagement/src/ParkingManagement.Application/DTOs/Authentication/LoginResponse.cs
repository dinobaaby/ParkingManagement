

namespace ParkingManagement.Application.DTOs.Authentication
{
    public record LoginResponse(UserDto userData, TokenDto token);
    
}
