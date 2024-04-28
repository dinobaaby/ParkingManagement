

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.DTOs.Authentication;
using ParkingManagement.Application.DTOs.Role;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Helpers;
using ParkingManagement.Domain.Entities.Authetication;
using ParkingManagement.Infrastucture.Data;

namespace ParkingManagement.Infrastucture.Repos
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IMemoryCache cache, IMapper mapper, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _cache = cache;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServerResponse> CreateRoleAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return new ServerResponse(null, false, "Role is null");
            }
            var checkRole = await _roleManager.RoleExistsAsync(roleName);
            if (checkRole)
            {
                return new ServerResponse(null, false, "RoleName is exist");
            }
            var role = new IdentityRole(roleName);
            var createRole = await _roleManager.CreateAsync(role);
            if (createRole.Succeeded)
            {
                _cache.Remove("RoleList");
                _cache.Remove($"Role_{role.Name}");
                return new ServerResponse(role, Message: "Create role successfull");
            }
            return new ServerResponse(role, false, "Create role faild");
        }

        public async Task<ServerResponse> DeleteRoleAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                 return new ServerResponse(null, false, "Role is null");
            }
            var checkRole = await _roleManager.FindByNameAsync(roleName);
            if (checkRole is null)
            {
                return new ServerResponse(null, false, "Permissions have not been created");
            }

            var deleteRole = await _roleManager.DeleteAsync(checkRole);
            if (deleteRole.Succeeded)
            {
                _cache.Remove("RoleList");
                _cache.Remove($"Role_{checkRole.Name}");
                return new ServerResponse(checkRole, Message: "Delete role successfull");
            }
            return new ServerResponse(null, false, Message: "Delete role faild");

        }

        public async Task<ServerResponse> GetAllRolesAsync()
        {
            if(_roleManager.Roles == null)
            {
                return new ServerResponse(null, false, "No copyright found");
            }
            if(!_cache.TryGetValue("RoleList", out IEnumerable<IdentityRole> listRoles))
            {
                listRoles = await _roleManager.Roles.ToListAsync();
                if(listRoles != null)
                {
                    _cache.Set("RoleList", listRoles, TimeSpan.FromMinutes(10));
                }
            }
            
            return new ServerResponse(listRoles, Message:"Get role successfull");
        }

        public async Task<ServerResponse> GetTotalUserRoleAsync()
        {
            if(!_cache.TryGetValue($"RoleList", out List<RoleResponse> roleResponses))
            {
                var findRole = await _roleManager.Roles.ToListAsync();
                if (findRole == null)
                {
                    return new ServerResponse(null, false, "No copyright found");
                }
                roleResponses = new List<RoleResponse>();
                foreach (var role in findRole)
                {
                    var totalUser = await _userManager.GetUsersInRoleAsync(role.Name!);
                    roleResponses.Add(new RoleResponse()
                    {
                        RoleId = role.Id,
                        RoleName = role.Name!,
                        TotalUser = totalUser.Count()
                    });
                }
                
                if(findRole != null)
                {
                    _cache.Set($"RoleList", roleResponses, TimeSpan.FromMinutes(10));
                }
            }
            return new ServerResponse(roleResponses, Message: "Get role successfull");
        }

        

        public async Task<ServerResponse> GetUserByRoleAsync(string roleName, int pageIndex, int pageSize)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return new ServerResponse(null, false, "No copyright found");
            }
            var users = await _userManager.GetUsersInRoleAsync(roleName);
            if (users != null)
            {
                return new ServerResponse(new object { }, true, $"There are no users with {roleName} role");
            }
            IQueryable<UserDto> userReponse = _mapper.Map<IQueryable<UserDto>>(users);
            var result = new UserRoleResponse
            {
                RoleDetails = new RoleResponse
                {
                    RoleId = role.Id,
                    RoleName = roleName,
                    TotalUser = users!.Count(),
                },
                Users = PaginatedList<UserDto>.Create(userReponse, pageIndex, pageSize)
            };

            return new ServerResponse(result, true, "Get user by role success");
        }

        public async Task<ServerResponse> UpdateRoleAsync(IdentityRole role)
        {
            var findRole = await _roleManager.FindByIdAsync(role.Id!);
            if (findRole == null)
            {
                return new ServerResponse(null, false, "No copyright found"); 
            }       
            findRole.Name = role.Name;
            findRole.NormalizedName = role.Name!.ToUpper();
            await _context.SaveChangesAsync();

            return new ServerResponse(findRole, true, "Update role successful");
        }

    }
}
