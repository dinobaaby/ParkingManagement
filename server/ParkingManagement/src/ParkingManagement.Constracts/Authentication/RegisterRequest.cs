

namespace ParkingManagement.Constracts.Authentication
{
    public record RegisterRequest
    (
        string Email,
        string UserName,
        string Password,
        string CardId,
        string PhoneNumber
        );
}
