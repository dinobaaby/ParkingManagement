using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;

namespace ParkingManagement.Webserver.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var result = await _roleService.GetAllRolesAsync();
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            try
            {
                var result = await _roleService.CreateRoleAsync(name);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null,IsSuccess : false, Message:  ex.Message));
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(IdentityRole role)
        {
            try
            {
                var result = await _roleService.UpdateRoleAsync(role);
                if(!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, IsSuccess: false, Message: ex.Message));
            }
        }

        [HttpDelete("{roleName}")]
        public async Task<IActionResult> Delete(string roleName)
        {
            try
            {
                var result = await _roleService.DeleteRoleAsync(roleName);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, IsSuccess: false, Message: ex.Message));
            }
        }

        [HttpGet("GetRoleWithUser")]
        public async Task<IActionResult> GetRoleWithUser()
        {
            try
            {
                var result = await _roleService.GetTotalUserRoleAsync();
                if(result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, IsSuccess: false, Message: ex.Message));
            }
        }
    }
}
