


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ParkingManagement.Application.Services;
using ParkingManagement.Domain.Entities.Authetication;

namespace ParkingManagement.Infrastucture.Repos
{
    public class AccountService : IAccountService
    {
        private readonly IServiceRepo<ApplicationUser, string> _servicerepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMemoryCache _cache;
        public AccountService(IServiceRepo<ApplicationUser, string> service, IMemoryCache cache, UserManager<ApplicationUser> userManager)
        {
            _servicerepo = service;
            _cache = cache;
            _userManager = userManager;

        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser model)
        {
            _cache.Remove($"User_{model.Id}");
            _cache.Remove("UserList");
            return await _servicerepo.CreateAsync(model);
            
        }

        public async Task<bool> DeleteAsync(string email)
        {
            ApplicationUser user
                = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }
            try
            {
                await _userManager.DeleteAsync(user);

                _cache.Remove($"User_{user.Email}");
                _cache.Remove("UserList");

                return true; 
            }
            catch (Exception ex)
            {
               
                throw new Exception("Error occurred while deleting user.", ex);
            }
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            if(!_cache.TryGetValue($"User_{id}", out ApplicationUser user))
            {
                user = await _servicerepo.GetByIdAsync(id);
                if(user != null)
                {
                    _cache.Set($"User_{id}", user, TimeSpan.FromMinutes(10));
                }
            }
            return user;
        }

        public async Task<IEnumerable<ApplicationUser>> GetByNameAsync(string name)
        {
            var cacheKey= $"UserByName_{name}";
            if(!_cache.TryGetValue(cacheKey , out IEnumerable<ApplicationUser> user))
            {
                user = await _userManager.Users.Where(u => u.UserName.Contains(name)).ToListAsync();
                if(user != null)
                {
                    _cache.Set(cacheKey, user, TimeSpan.FromMinutes(10));
                }
            }
            return user;
        }

        public async Task<IEnumerable<ApplicationUser>> GetListAsync()
        {
            if(!_cache.TryGetValue("UserList", out IEnumerable<ApplicationUser> userList))
            {
                userList = await _servicerepo.GetAllAsync();
                if (userList != null)
                {
                    _cache.Set("UserList", userList, TimeSpan.FromMinutes(10));
                }
            }

            return userList;
        }

        public async Task<bool> UpdateAsync(ApplicationUser model)
        {
            var account = await _userManager.FindByEmailAsync(model.Email!);
            if (account == null)
            {
                return false;
            }

           
            _cache.Remove($"User_{model.Id}");
            _cache.Remove("UserList");


            await _userManager.UpdateAsync(account);
            return true;
        }
    }
}
