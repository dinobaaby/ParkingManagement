

using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersByNameAsync(string name, int pageIndex, int pageSize);

        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync(int pageIndex, int pageSize);

        Task<CustomerDto> GetCustomerByIdAsync(int id);

        Task<CustomerDto> CreateCustomerAsync(Customer customer);

        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<IEnumerable<CustomerDto>> GetCustomerByPhoneAsync(string phone);
    }
}
