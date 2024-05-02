using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Webserver.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService ,IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCustomer(int pageIndex, int pageSize)
        {
            try
            {
                var result = await _customerService.GetAllCustomersAsync(pageIndex, pageSize);
                return Ok(new ServerResponse(result, true, "Customers Fetched Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var result = await _customerService.GetCustomerByIdAsync(id);
                return Ok(new ServerResponse(result, true, "Customer Fetched Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpGet("GetCustomerByName")]
        public async Task<IActionResult> GetCustomerByName(string name, int pageIndex, int pageSize)
        {
            try
            {
                var result = await _customerService.GetAllCustomersByNameAsync(name, pageIndex, pageSize);
                return Ok(new ServerResponse(result, true, "Customers Fetched Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }
        [HttpGet("GetCustomerByPhone")]
        public async Task<IActionResult> GetCustomerByPhone(string phone)
        {
            try
            {
                var result = await _customerService.GetCustomerByPhoneAsync(phone);
                return Ok(new ServerResponse(result, true, "Customers Fetched Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto dto)
        {
            try
            {
                Customer model = _mapper.Map<Customer>(dto);
                var result = await _customerService.CreateCustomerAsync(model);
                return Ok(new ServerResponse(result, true, "Customer Created Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isSuccess = await _customerService.DeleteCustomerAsync(id);
                if (isSuccess)
                {
                    return Ok(new ServerResponse(null, true, "Customer Deleted Successfully"));
                }
                return NotFound(new ServerResponse(null, false, "Customer Not Found"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto dto)
        {
            try
            {
                Customer model = _mapper.Map<Customer>(dto);
                bool isSuccess = await _customerService.UpdateCustomerAsync(model);
                if (isSuccess)
                {
                    return Ok(new ServerResponse(null, true, "Customer Updated Successfully"));
                }
                return BadRequest(new ServerResponse(null, false, "Customer Update faild"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }
    }
}
