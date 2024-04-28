using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.DTOs.Accout;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Authentication;
using ParkingManagement.Domain.Entities.Authetication;

namespace ParkingManagement.Webserver.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;
        private IMapper _mapper;
        
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccout()
        {
            try
            {
                var result = await _accountService.GetListAsync();
                if(result is null)
                {
                    return BadRequest(new ServerResponse(null, false, "Get account error"));
                }
                IEnumerable<AccountResponse> accounts = _mapper.Map<IEnumerable<AccountResponse>>(result);

                return Ok(new ServerResponse(accounts, true, "Get list account success"));

            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccout(RegisterRequest model)
        {
            try
            {
                ApplicationUser user = new()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    NormalizedEmail = model.Email,
                    CardId = model.CardId,
                    PhoneNumber = model.PhoneNumber,
                };
                var result = await _accountService.CreateAsync(user);
                if(result is null)
                {
                    return BadRequest(new ServerResponse(null, false, "Create account error"));
                }
                var userData = _mapper.Map<AccountResponse>(result);
                return Ok(new ServerResponse(userData, true, "Create account success"));
            }
            catch (Exception ex) 
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update(AccountResponse model)
        {
            try
            {
               
                ApplicationUser user = new ApplicationUser
                {
                    Id = model.Id,
                    UserName = model.UserName,
                    Email = model.Email,
                    CardId = model.CardId,
                    PhoneNumber = model.PhoneNumber,
                };

               
                var result = await _accountService.UpdateAsync(user);

                if (!result)
                {
                    return BadRequest(new ServerResponse(null, false, "Update account error"));
                }

                // Successfully updated
                return Ok(new ServerResponse(null, true, "Update account success"));
            }
            catch (Exception ex)
            {
                // Exception occurred during update
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            try
            {
                bool isSuccess = await _accountService.DeleteAsync(email);
                if (!isSuccess)
                {
                    return BadRequest(new ServerResponse(null, false, "Delete faild"));
                }
                return Ok(new ServerResponse(null,Message: "Delete success"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }

        [HttpGet("GetUserByName")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            try
            {
                var result = await _accountService.GetByNameAsync(name);
                if(result == null)
                {
                    return NotFound(new ServerResponse(null, false, $"User by {name} not found"));
                }
                var userData = _mapper.Map<IEnumerable<AccountResponse>>(result);
                return Ok(new ServerResponse(userData, Message:"Get user successfull"));
            }catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message.ToString()));
            }
        }
    }
}
