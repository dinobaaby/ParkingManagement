

using Microsoft.Extensions.Caching.Memory;
using ParkingManagement.Application.Services;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Repos
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IServiceRepo<VehicleType, int> _serviceRepo;
        private readonly IMemoryCache _cache;


        public VehicleTypeService(IServiceRepo<VehicleType, int> serviceRepo, IMemoryCache cache)
        {
            _serviceRepo = serviceRepo;
            _cache = cache;
        }
       


        public async Task<VehicleType> CreateVehicleTypeAsync(VehicleType vehicleType)
        {
           
            _cache.Remove("ListVehicleType");
            var createVehicleType = await _serviceRepo.CreateAsync(vehicleType);
            if(createVehicleType is not null)
            {
                return createVehicleType;
            }
            return null!;
        }

        public async Task<bool> DeleteVehicleTypeAsync(int id)
        {
           
            _cache.Remove($"VehicleType_{id}");
            _cache.Remove("ListVehicleType");
            var deleteVehicleType = await _serviceRepo.GetByIdAsync(id);
            if (deleteVehicleType is not null)
            {
                await _serviceRepo.DeleteAsync(deleteVehicleType);
                return true;
            }
            return false;
        }

        public async Task<VehicleType> GetVehicleTypeByIdAsync(int id)
        {
            if(!_cache.TryGetValue($"VehicleType_{id}", out VehicleType? vehicleType))
            {
                vehicleType = await _serviceRepo.GetByIdAsync(id);
                if (vehicleType is not null)
                {
                    _cache.Set($"VehicleType_{id}", vehicleType, TimeSpan.FromMinutes(10));
                }
            }
            return vehicleType!;
        }

        public async Task<IEnumerable<VehicleType>> GetVehicleTypeByNameAsync(string name)
        {
            if(!_cache.TryGetValue($"ListVehicleType_{name}", out IEnumerable<VehicleType>? vehicleTypes))
            {
                vehicleTypes = await _serviceRepo.GetByNameAsync(x => x.VehicleTypeName.ToLower().Contains(name.ToLower()));
                if(vehicleTypes is not null )
                {
                    _cache.Set($"ListVehicleType_{name}", vehicleTypes, TimeSpan.FromMinutes(10));
                }
            }

            return vehicleTypes!;
        }

        public async Task<IEnumerable<VehicleType>> GetVehicleTypesAsync()
        {
            if(!_cache.TryGetValue("ListVehicleType", out IEnumerable<VehicleType>? vehicleTypes))
            {
                vehicleTypes = await _serviceRepo.GetAllAsync();

                if(vehicleTypes is not null)
                {
                    _cache.Set("ListVehicleType", vehicleTypes, TimeSpan.FromMinutes(10));
                }
            }

            return vehicleTypes!;
        }

        public async Task<bool> UpdateVehicleTypeAsync(VehicleType vehicleType)
        {
            _cache.Remove($"VehicleType_{vehicleType.VehicleTypeId}");
            _cache.Remove("ListVehicleType");
            var result = await _serviceRepo.UpdateAsync(vehicleType);
            if (result is not null)
            {
                return true;
            }

            return false;
        }
    }
}
