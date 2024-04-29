

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using ParkingManagement.Application.Services;
using ParkingManagement.Domain.Entities;
using System.Security.Claims;

namespace ParkingManagement.Infrastucture.Repos
{
    public class AreaService : IAreaService
    {
        private readonly IServiceRepo<Area, int> _repository;
        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AreaService(IServiceRepo<Area, int> repository, IMemoryCache cache, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Area> CreateAsync(Area area)
        {

            var currentUserClaims = _httpContextAccessor.HttpContext.User.Claims.ToList();

            area.UserId = currentUserClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;



            _cache.Remove("AreaList");
            
            var createArea = await _repository.CreateAsync(area);
            if(createArea != null)
            {
                return createArea;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _cache.Remove("AreaList");
            _cache.Remove($"Area_{id}");
            var area = await _repository.GetByIdAsync(id);
            if (area is not null)
            {
                await _repository.DeleteAsync(area);
                return true;
            }

            return false;

        }

        public async Task<Area> GetByIdAsync(int id)
        {
            if (!_cache.TryGetValue($"Area_{id}", out Area area)){
                area = await _repository.GetByIdAsync(id);
                if(area is not null)
                {
                    _cache.Set($"Area_{id}", area, TimeSpan.FromMinutes(10));
                }

            }
            return area;
        }

        public async Task<IEnumerable<Area>> GetByNameAsync(string name)
        {
            if(!_cache.TryGetValue($"Area_{name}", out IEnumerable<Area> area))
            {
                area = await _repository.GetByNameAsync(s => s.AreaName == name);
                if(area is not null)
                {
                    _cache.Set($"Area_{name}", area, TimeSpan.FromMinutes(10));
                }
            }

            return area;


        }

        public async Task<IEnumerable<Area>> GetListAsync()
        {
            if(!_cache.TryGetValue("AreaList", out IEnumerable<Area> areas))
            {
                areas = await _repository.GetAllAsync();
                if(areas is not null)
                {
                    _cache.Set("AreaList", areas, TimeSpan.FromMinutes(10));
                }
            }

            return areas;
        }

        public async Task<bool> UpdateAsync(Area area)
        {
            _cache.Remove("AreaList");
            _cache.Remove($"Area_{area.AreaName}");
            _cache.Remove($"Area_{area.AreaId}");
            var updateArea = await _repository.UpdateAsync(area);
            if(updateArea is not null)
            {
                return true;
            }
            return false;

        }
    }
}
