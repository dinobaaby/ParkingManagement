
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync(int pageIndex,int pageSize);
        Task<PaymentDto> GetPaymentByIdAsync(int paymentId);
        Task<PaymentDto> CreatePaymentAsync(PaymentDto newPayment);
        Task<PaymentDto> UpdatePaymentAsync(PaymentDto paymentDto);
        Task<bool> DeletePaymentAsync(int paymentId);

    }
}
