
namespace ParkingManagement.Application.DTOs
{
    public record ServerResponse(object? Result, bool IsSuccess = true, string Message = "")
    {
      
    }
}
