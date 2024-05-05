using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;

namespace ParkingManagement.Webserver.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            try
            {
                var response = await _vehicleService.GetAllVehiclesAsync();
                return Ok(new ServerResponse(response, true, "Vehicles retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            try
            {
                var response = await _vehicleService.GetVehicleByIdAsync(id);
                return Ok(new ServerResponse(response, true, "Vehicle retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpGet("GetByCustomer/{customerId}")]
        public async Task<IActionResult> GetVehiclesByCustomer(int customerId)
        {
            try
            {
                var response = await _vehicleService.GetAllVehiclesByCustomerAsync(customerId);
                return Ok(new ServerResponse(response, true, "Vehicles retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }


        [HttpGet("GetByType/{vehicleTypeId}")]
        public async Task<IActionResult> GetVehiclesByType(int vehicleTypeId)
        {
            try
            {
                var response = await _vehicleService.GetAllVehiclesByTypeAsync(vehicleTypeId);
                return Ok(new ServerResponse(response, true, "Vehicles retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpGet]
        [Route("GetByPlateNumber/{plateNumber}")]
        public async Task<IActionResult> GetByPlateNumber(string plateNumber)
        {
            try
            {
                var response = await _vehicleService.GetAllVehiclesByPlateNumberAsync(plateNumber);
                return Ok(new ServerResponse(response, true, "Vehicles retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] VehicleDto dto, IFormFile file)
        {
            try
            {
                var response = await _vehicleService.AddVehicleAsync(dto, file);
                return Ok(new ServerResponse(response, true, "Vehicle created successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VehicleDto dto)
        {
            try
            {
                var response = await _vehicleService.UpdateVehicleAsync(dto);
                return Ok(new ServerResponse(response, true, "Vehicle updated successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _vehicleService.DeleteVehicleAsync(id);
                return Ok(new ServerResponse(response, true, "Vehicle deleted successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }






    }
}
