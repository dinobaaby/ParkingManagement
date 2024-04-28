

using ParkingManagement.Constracts.Helpers;

namespace ParkingManagement.Application.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest request);

        Task SendEmailConfirmAccountAsync(string email,string token, string controllerName, string actionName);
    }
}
