
using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Helpers;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Repos
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepo<Payment, int> _repo;

        public PaymentService(IMapper mapper, IServiceRepo<Payment, int> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<PaymentDto> CreatePaymentAsync(PaymentDto newPayment)
        {
            Payment payment = _mapper.Map<Payment>(newPayment);
            var createdPayment = await _repo.CreateAsync(payment);
            if(createdPayment == null)
            {
                return null!;
            }
            return _mapper.Map<PaymentDto>(createdPayment);
        }

        public Task<bool> DeletePaymentAsync(int paymentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync(int pageIndex, int pageSize)
        {
            var payments = await _repo.GetAllAsync();
            var paymentsByPage = PaginatedList<Payment>.Create(payments.AsQueryable(), pageIndex, pageSize);
            return _mapper.Map<IEnumerable<PaymentDto>>(paymentsByPage);
        }

        public Task<PaymentDto> GetPaymentByIdAsync(int paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDto> UpdatePaymentAsync(PaymentDto paymentDto)
        {
            throw new NotImplementedException();
        }
    }
}
