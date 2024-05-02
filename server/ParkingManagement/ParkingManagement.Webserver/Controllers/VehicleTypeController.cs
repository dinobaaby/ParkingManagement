using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;
using ParkingManagement.Domain.Entities;


namespace ParkingManagement.Webserver.Controllers
{
    [ApiController]
    [Route("api/vehicletype")]
    public class VehicleTypeController : Controller
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IMapper _mapper;
        public VehicleTypeController(IVehicleTypeService vehicleTypeService, IMapper mapper)
        {
            _vehicleTypeService = vehicleTypeService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Create(VehicleTypeDto vehicle)
        {
            try
            {
                VehicleType vehicleType = _mapper.Map<VehicleType>(vehicle);
                var result = await _vehicleTypeService.CreateVehicleTypeAsync(vehicleType);
                return Ok(new ServerResponse(result, true, "Vehicle Type Created Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleType()
        {
            try
            {
                var result = await _vehicleTypeService.GetVehicleTypesAsync();
                IEnumerable<VehicleTypeDto> response = _mapper.Map<IEnumerable<VehicleTypeDto>>(result);
                return Ok(new ServerResponse(response, true, "Vehicle Type Fetched Successfully"));
            }
            catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            try 
            { 
                var response = await _vehicleTypeService.GetVehicleTypeByIdAsync(id);
                VehicleTypeDto result = _mapper.Map<VehicleTypeDto>(response);   
                return Ok(new ServerResponse(result, true, "Vehicle Type Fetched Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleType(int id)
        {
            try
            {
                bool isSuccess = await _vehicleTypeService.DeleteVehicleTypeAsync(id);
                if (isSuccess)
                {
                    return Ok(new ServerResponse(null, true, "Vehicle Type Deleted Successfully"));
                }
                return BadRequest(new ServerResponse(null, false, "Vehicle Type Not Found"));
            }
            catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicleType(VehicleTypeDto vehicle)
        {
            try
            {
                VehicleType vehicleType = _mapper.Map<VehicleType>(vehicle);
                bool isSuccess = await _vehicleTypeService.UpdateVehicleTypeAsync(vehicleType);
                if (isSuccess)
                {
                    return Ok(new ServerResponse(null, true, "Vehicle Type Updated Successfully"));
                }
                return BadRequest(new ServerResponse(null, false, "Vehicle Type Not Found"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpGet("GetVehicleTypeByName")]
        public async Task<IActionResult> GetVehicleTypeByName(string name)
        {
            try
            {
                var result = await _vehicleTypeService.GetVehicleTypeByNameAsync(name);
                IEnumerable<VehicleTypeDto> response = _mapper.Map<IEnumerable<VehicleTypeDto>>(result);
                return Ok(new ServerResponse(response, true, "Vehicle Type Fetched Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

    }
}
