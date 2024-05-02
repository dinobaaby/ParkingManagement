

using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Services
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleType>> GetVehicleTypesAsync();
        Task<IEnumerable<VehicleType>> GetVehicleTypeByNameAsync(string name);

        Task<VehicleType> GetVehicleTypeByIdAsync(int id);

        Task<VehicleType> CreateVehicleTypeAsync(VehicleType vehicleType);

        Task<bool> DeleteVehicleTypeAsync(int id);

        Task<bool> UpdateVehicleTypeAsync(VehicleType vehicleType);

    }
}
