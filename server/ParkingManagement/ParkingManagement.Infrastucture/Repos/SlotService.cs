using Microsoft.Extensions.Caching.Memory;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Helpers;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Repos
{
    public class SlotService : ISlotService
    {
        private readonly IServiceRepo<Slot, int> _repo;
        private readonly IMemoryCache _cache;
        public SlotService(IServiceRepo<Slot, int> repo, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        private void RemoveCache(string key)
        {
            
            var cacheEntriesCollectionDefinition = typeof(IMemoryCache).Assembly.GetType("Microsoft.Extensions.Caching.Memory.CacheEntriesCollection");
            var cache = _cache as IMemoryCache;
            var cacheEntriesCollection = cacheEntriesCollectionDefinition!.GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!.GetValue(cache) as ICollection<KeyValuePair<object, object>>;

            
            foreach (var cacheItem in cacheEntriesCollection)
            {
                if (cacheItem.Key.ToString()!.StartsWith(key))
                {
                    cache.Remove(cacheItem.Key);
                }
            }
        }


        public async Task<Slot> CreateSlotAsync(Slot slot)
        {

            
            var slotCreate = await _repo.CreateAsync(slot);
            if(slotCreate is not null)
            {
                return slotCreate;
            }
            return null!;
        }

        public async Task<bool> DeleteSlotAsync(int slotId)
        {
            
            var slotDelete = await _repo.GetByIdAsync(slotId);
            if(slotDelete is not null)
            {
                await _repo.DeleteAsync(slotDelete);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Slot>> GetAllSlotsAsync(int pageIndex, int pageSize)
        {
            
            
            if (!_cache.TryGetValue($"ListSlot_{pageIndex}_{pageSize}", out IEnumerable<Slot>? slots))
            {
                var listSlots = await _repo.GetAllAsync();
                var getSlotByPage = PaginatedList<Slot>.Create(listSlots.AsQueryable(), pageIndex, pageSize);
                slots = getSlotByPage.ToList();
                if(listSlots is not null)
                {
                    _cache.Set("ListSlot", slots, TimeSpan.FromMinutes(10));
                }
            }


            return slots!;

            
        }

        public async Task<IEnumerable<Slot>> GetSlotByAreaAsync(int areaId, int pageIndex, int pageSize)
        {
            if(!_cache.TryGetValue($"ListSlotByArea{areaId}_{pageIndex}_{pageSize}", out IEnumerable<Slot>? slots))
            {
                var listSlot = await _repo.GetAllAsync();
                var getSlotByAreaPage = PaginatedList<Slot>.Create(listSlot.AsQueryable().Where(c => c.AreaId == areaId), pageIndex, pageSize);
                slots = getSlotByAreaPage.ToList();
                if(listSlot is not null)
                {
                    _cache.Set($"ListSlotByArea_{pageIndex}_{pageSize}", slots, TimeSpan.FromMinutes(10));
                }
            }

            return slots!;
        }

        public async Task<Slot> GetSlotByIdAsync(int slotId)
        {
            if (!_cache.TryGetValue($"Slot_{slotId}", out Slot? slot))
            {
                slot = await _repo.GetByIdAsync(slotId);
                if (slot is not null)
                {
                    _cache.Set($"{slotId}", slot, TimeSpan.FromMinutes(10));
                }
            }
            return slot!;
        }

        public async Task<IEnumerable<Slot>> GetSlotByNameAsync(string name, int pageIndex, int pageSize)
        {
            if(!_cache.TryGetValue($"ListSlotByName_{name}_{pageIndex}_{pageSize}", out IEnumerable<Slot>? slots))
            {
                var result = await _repo.GetByNameAsync(c => c.SlotName == name);
                slots = PaginatedList<Slot>.Create(result.AsQueryable(), pageIndex, pageSize);
                if(slots is not null)
                {
                    _cache.Set($"ListSlotByName_{name}_{pageIndex}_{pageSize}", slots, TimeSpan.FromMinutes(10));
                }
            }

            return slots!;
        }

        public async Task<bool> UpdateSlotAsync(Slot slot)
        {
            //RemoveCache("ListSlot");
            //_cache.Remove($"Slot_{slot.SlotId}");

            var slotUpdate = await _repo.UpdateAsync(slot);
            if(slotUpdate is not null)
            {
                return true;
            }

            return false;
        }
    }
}
