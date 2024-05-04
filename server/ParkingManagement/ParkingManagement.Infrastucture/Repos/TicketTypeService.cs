

using Microsoft.Extensions.Caching.Memory;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Helpers;
using ParkingManagement.Domain.Entities;
using System.Collections;

namespace ParkingManagement.Infrastucture.Repos
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly IServiceRepo<TicketType, int> _serviceRepo;
        private readonly IMemoryCache _cache;
        public TicketTypeService(IServiceRepo<TicketType, int> serviceRepo, IMemoryCache cache)
        {
            _serviceRepo = serviceRepo;
            _cache = cache;
        }
        public void RemoveCacheEntriesStartingWith(string value)
        {
            // Ensure _cache is not null
            if (_cache == null)
            {
                throw new NullReferenceException("_cache is not initialized.");
            }

            // Get all keys from the cache
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).Assembly.GetType("Microsoft.Extensions.Caching.Memory.CacheEntryCollection");
            var cacheEntriesCollection = _cache.GetType().GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(_cache);
            var cacheCollectionValues = cacheEntriesCollectionDefinition?.GetMethod("get_CacheValues")?.Invoke(cacheEntriesCollection, null) as ICollection;
            var cacheKeys = new List<string>();
            if (cacheCollectionValues != null)
            {
                foreach (var cacheItem in cacheCollectionValues)
                {
                    var key = cacheItem?.GetType().GetProperty("Key")?.GetValue(cacheItem) as string;
                    if (key != null && key.StartsWith(value))
                    {
                        cacheKeys.Add(key);
                    }
                }
            }

            // Remove cache entries that start with the specified value
            foreach (var key in cacheKeys)
            {
                _cache.Remove(key);
            }
        }


        public async Task<TicketType> CreateTicketTypeAsync(TicketType ticketType)
        {
            RemoveCacheEntriesStartingWith("ListTicketType");
            var result = await _serviceRepo.CreateAsync(ticketType);
         
            return result;
        }

        public async Task<bool> DeleteTicketTypeAsync(int id)
        {
            RemoveCacheEntriesStartingWith("ListTicketType");
            _cache.Remove($"TicketType_{id}");
            var result = await _serviceRepo.GetByIdAsync(id);
            if(result == null)
            {
                return false;
            }
            await _serviceRepo.DeleteAsync(result);
            return true;
        }

        public async Task<IEnumerable<TicketType>> GetAllTicketTypesAsync(int pageIndex, int pageSize)
        {
            if(!_cache.TryGetValue($"ListTicketType_{pageIndex}_{pageSize}", out IEnumerable<TicketType>? ticketTypes))
            {
                ticketTypes = await _serviceRepo.GetAllAsync();
                var ticketTypeForPage = PaginatedList<TicketType>.Create(ticketTypes.AsQueryable(), pageIndex, pageSize);
                if(ticketTypes != null)
                {
                    _cache.Set($"ListTicketType_{pageIndex}_{pageSize}", ticketTypeForPage.AsEnumerable(), TimeSpan.FromMinutes(10));
                }
            }

            return ticketTypes!;
        }

        public async Task<TicketType> GetTicketTypeByIdAsync(int id)
        {
            if(!_cache.TryGetValue($"TicketType_{id}", out TicketType? ticketType))
            {
                ticketType = await _serviceRepo.GetByIdAsync(id);
                if (ticketType != null)
                {
                    _cache.Set($"TicketType_{id}", ticketType, TimeSpan.FromMinutes(10));
                }
            }

            return ticketType!;
        }

        public async Task<IEnumerable<TicketType>> GetTicketTypesByNameAsync(string name, int pageIndex, int pageSize)
        {
            if(!_cache.TryGetValue($"ListTicketType_{name}", out IEnumerable<TicketType>? ticketTypes ))
            {
                var result = await _serviceRepo.GetByNameAsync(s => s.TicketTypeName == name);
                ticketTypes = PaginatedList<TicketType>.Create(result.AsQueryable(), pageIndex, pageSize);
                if(ticketTypes != null)
                {
                    _cache.Set($"ListTicketType_{name}", ticketTypes, TimeSpan.FromMinutes(10));
                }
            }

            return ticketTypes!;

        }

        public async Task<bool> UpdateTicketTypeAsync(TicketType ticketType)
        {
            RemoveCacheEntriesStartingWith("ListTicketType");
            _cache.Remove($"TicketType_{ticketType.TicketTypeId}");
            var result = await _serviceRepo.UpdateAsync(ticketType);
            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}
