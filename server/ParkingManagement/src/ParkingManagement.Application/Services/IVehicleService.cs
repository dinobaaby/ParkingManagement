

using Microsoft.AspNetCore.Http;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync();
        Task<IEnumerable<VehicleDto>> GetAllVehiclesByCustomerAsync(int customerId);
        Task<IEnumerable<VehicleDto>> GetAllVehiclesByTypeAsync(int vehicleTypeId);
        Task<IEnumerable<VehicleDto>> GetAllVehiclesByPlateNumberAsync(string plateNumber);
        Task<VehicleDto> GetVehicleByIdAsync(int id);
        Task<VehicleDto> AddVehicleAsync(VehicleDto vehicleDto, IFormFile file);
        Task<VehicleDto> UpdateVehicleAsync(VehicleDto vehicleDto);
        Task<VehicleDto> DeleteVehicleAsync(int id);

    }
}
