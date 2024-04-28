

namespace ParkingManagement.Application.DTOs.Authentication
{
    public record ForgotPasswordResponse(string Email = "", string Token = 
        "");
    
    
}
