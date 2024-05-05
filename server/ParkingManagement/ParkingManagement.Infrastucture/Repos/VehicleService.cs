

using AutoMapper;
using Microsoft.AspNetCore.Http;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Repos
{
    public class VehicleService : IVehicleService
    {
        private readonly IServiceRepo<Vehicle, int> _serviceRepo;
        private readonly IMapper _mapper;
        private readonly IUploadFileService _uploadFileService;

        public VehicleService(IServiceRepo<Vehicle, int> serviceRepo, IMapper mapper, IUploadFileService uploadFileService)
        {
            _serviceRepo = serviceRepo;
            _mapper = mapper;
            _uploadFileService = uploadFileService;
        }

        public async Task<VehicleDto> AddVehicleAsync(VehicleDto vehicleDto, IFormFile file)
        {
            vehicleDto.VehicleImage = (await _uploadFileService.UploadFileAsync(file, "Vehicles")) ?? "don't exist";
            Vehicle vehicle = _mapper.Map<Vehicle>(vehicleDto);
            var result = await _serviceRepo.CreateAsync(vehicle);
            if (result != null)
            {
                return _mapper.Map<VehicleDto>(result);
            }
            return null!;
        }

        

        public async Task<VehicleDto> DeleteVehicleAsync(int id)
        {
            var vehicle = await _serviceRepo.GetByIdAsync(id);
            if (vehicle != null)
            {
                var result = await _serviceRepo.DeleteAsync(vehicle);
                if (result != null)
                {
                    return _mapper.Map<VehicleDto>(result);
                }
            }

            return null!;
        }

        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _serviceRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
        }

        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesByCustomerAsync(int customerId)
        {
            var vehicles = await _serviceRepo.GetAllAsync();
            var vehiclesByCustomer = vehicles.Where(v => v.CustomerId == customerId);
            return _mapper.Map<IEnumerable<VehicleDto>>(vehiclesByCustomer);
        }

        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesByPlateNumberAsync(string plateNumber)
        {
            var vehicles = await _serviceRepo.GetByNameAsync(s => s.VehiclePlateNumber.ToLower().Contains(plateNumber.ToLower()));
            return _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
        }

        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesByTypeAsync(int vehicleTypeId)
        {
            var vehicles = await _serviceRepo.GetAllAsync();
            var vehiclesByType = vehicles.Where(v => v.VehicleTypeId == vehicleTypeId);
            return _mapper.Map<IEnumerable<VehicleDto>>(vehiclesByType);
        }

        public async Task<VehicleDto> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _serviceRepo.GetByIdAsync(id);
            if (vehicle != null)
            {
                return _mapper.Map<VehicleDto>(vehicle);
            }

            return null!;
        }

        public async Task<VehicleDto> UpdateVehicleAsync(VehicleDto vehicleDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);
            var result = await _serviceRepo.UpdateAsync(vehicle);
            if (result != null)
            {
                return _mapper.Map<VehicleDto>(result);
            }

            return null!;
        }
    }
}
