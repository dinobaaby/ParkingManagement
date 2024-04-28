
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Authentication;

namespace ParkingManagement.Webserver.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthenticationController(IAuthenticationService authenticationService, IRefreshTokenService refreshTokenService)
        {
            _authenticationService = authenticationService;
            _refreshTokenService = refreshTokenService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            try
            {
                var result = await _authenticationService.RegisterAsync(model);
                if (!result.IsSuccess || result.Result == null)
                {
                    return BadRequest(result);
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            try
            {
                var result = await _authenticationService.LoginAsync(model);
                if (!result.IsSuccess || result.Result == null)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _authenticationService.GetAllUsersAsync();
                if (!result.IsSuccess || result.Result == null)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }


        [HttpGet]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            try
            {
                var result = await _authenticationService.ConfirmEmailAsync(email, token);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(AssignRoleRequest model)
        {
            try
            {
                var result = await _authenticationService.AssignRoleAsync(model.Email, model.RoleName);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                var result = await _authenticationService.ForgotPasswordAsync(email);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {
            try
            {
                var result = await _authenticationService.ResetPasswordAsync(model);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }

        [HttpPatch("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest model)
        {
            try
            {
                var result = await _authenticationService.ChangePasswordAsync(model);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest model)
        {
            try
            {
                var result = await _refreshTokenService.RefreshTokenAsync(model);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }

        [HttpDelete("DeleteUser/{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            try
            {
                var result = await _authenticationService.DeleteUserAsync(email);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }
    }
}
