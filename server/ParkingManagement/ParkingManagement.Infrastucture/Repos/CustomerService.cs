
using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Helpers;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Repos
{
    public class CustomerService : ICustomerService
    {
        private readonly IServiceRepo<Customer, int> _serviceRepo;
        private readonly IMapper _mapper;

        public CustomerService(IServiceRepo<Customer, int> serviceRepo, IMapper mapper)
        {
            _serviceRepo = serviceRepo;
            _mapper = mapper;
        }

        public async Task<CustomerDto> CreateCustomerAsync(Customer customer)
        {
            var result = await _serviceRepo.CreateAsync(customer);
            if (result is not null)
            {
                var response = _mapper.Map<CustomerDto>(result);
                return response;
            }

            return null!;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _serviceRepo.GetByIdAsync(id);
            if(customer is not null)
            {
                await _serviceRepo.DeleteAsync(customer);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync(int pageIndex, int pageSize)
        {
            var response = await _serviceRepo.GetAllAsync();
            if (response is not null)
            {
                var result = _mapper.Map<IEnumerable<CustomerDto>>(response).AsQueryable();
                var customers = PaginatedList<CustomerDto>.Create(result, pageIndex, pageSize);
                return customers;
            }
            return null!;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersByNameAsync(string name, int pageIndex, int pageSize)
        {
            var response = await _serviceRepo.GetByNameAsync(s => s.CustomerName.ToLower().Contains(name.ToLower()));
            if (response is not null)
            {
                var result = _mapper.Map<IEnumerable<CustomerDto>>(response).AsQueryable();
                var customers = PaginatedList<CustomerDto>.Create(result, pageIndex, pageSize);
                return customers;
            }

            return null!;
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var result = await _serviceRepo.GetByIdAsync(id);
            if(result is not null)
            {
                var response = _mapper.Map<CustomerDto>(result);
                return response;
            }

            return null!;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomerByPhoneAsync(string phone)
        {
            var result = await _serviceRepo.GetByNameAsync(s => s.CustomerPhoneNumber.ToLower().Contains(phone.ToLower()));
            if(result is not null)
            {
                var response = _mapper.Map<IEnumerable<CustomerDto>>(result);
                return response;
            }

            return null!;
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            var result = await _serviceRepo.UpdateAsync(customer);
            if(result is not null)
            {
                return true;
            }
            return false;
        }
    }
}
