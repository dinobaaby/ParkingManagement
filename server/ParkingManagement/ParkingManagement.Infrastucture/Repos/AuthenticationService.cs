

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParkingManagement.Application.Common.Interface.Authentication;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.DTOs.Authentication;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Authentication;
using ParkingManagement.Constracts.Helpers;
using ParkingManagement.Domain.Entities.Authetication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParkingManagement.Infrastucture.Repos
{
    
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<ApplicationUser> _useManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;
        private  IMapper _mapper;
        private readonly JwtOptions _jwtOptions;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly IRefreshTokenService _refreshTokenService;
        public AuthenticationService(
            IJwtTokenGenerator jwtTokenGenerator,
            UserManager<ApplicationUser> useManager,
            RoleManager<IdentityRole> roleManager
            , SignInManager<ApplicationUser> signInManager,
            IEmailService emailService,  
            IMapper mapper, 
            IOptions<JwtOptions> jwtOptions,
            TokenValidationParameters tokenValidationParameters,
            IRefreshTokenService refreshTokenService)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _useManager = useManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _mapper = mapper;
            _jwtOptions = jwtOptions.Value;
            _tokenValidationParameters = tokenValidationParameters;
            _refreshTokenService =refreshTokenService;
        }

        public async Task<ServerResponse> AssignRoleAsync(string email, string rolename)
        {
            var user = await _useManager.FindByEmailAsync(email);
            if(user is null)
            {
                return new ServerResponse(null, false, "User don't exist'");
            }
            if(!_roleManager.RoleExistsAsync(rolename).GetAwaiter().GetResult())
            {
                return new ServerResponse(null, false, "Role don't exist");
            }

            await _useManager.AddToRoleAsync(user, rolename);

            return new ServerResponse(null, true, "Assign role successfull");
        }

        public async Task<ServerResponse> ConfirmEmailAsync(string email, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            

            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);

            var jwtToken = validatedToken as JwtSecurityToken;

            if(jwtToken is null 
                || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ServerResponse(null, false, "Invalid token 1");
            }

            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
            if(userIdClaim is null)
            {
                return new ServerResponse(null, false, "Invalid token 2");
            }
            var userIdFromToken = userIdClaim.Value;
            if(userIdFromToken is null)
            {
                return new ServerResponse(null, false, "Invalid token 3");
            }
            var user = await FindUserByEmailAsync(email);
            user.EmailConfirmed = true;
            await _useManager.UpdateAsync(user);
            
            return new ServerResponse(null, true, "Confirm email successfull");
        }

        public async Task<ServerResponse> ForgotPasswordAsync(string email)
        {
            var user = await FindUserByEmailAsync(email);
            if(user is null)
            {
                return new ServerResponse(null, false, "User don't exist'");
            }
            var token = await _useManager.GeneratePasswordResetTokenAsync(user);

            await _emailService.SendEmailConfirmAccountAsync(email, token, "auths", "forgotpassword");

            ForgotPasswordResponse response = new ForgotPasswordResponse
            {
                Email = email,
                Token = token
            };

            return new ServerResponse(response, true, "Success");

        }

        public async Task<ServerResponse> GetAllUsersAsync()
        {
            if (_useManager.Users is not null)
            {
                var users = await _useManager.Users.ToListAsync();
                if (users.Count > 0)
                {
                    IEnumerable<UserDto> result = _mapper.Map<IEnumerable<UserDto>>(users);
                    return new ServerResponse(result, true, "Get User Successful");
                }
            }

            return new ServerResponse(null, false, "Cannot see user information");
        }

        public async Task<ServerResponse> LoginAsync(LoginRequest model)
        {
            var user = await _useManager.FindByEmailAsync(model.Email);
            if(user is  null)
            {
                return new ServerResponse(null, false, "Account don't exist");
            }
            bool isCheckPassword = await _useManager.CheckPasswordAsync(user, model.Password);
            if (!isCheckPassword)
            {
                user.LockoutEnabled = true;
                user.AccessFailedCount++;
                if(user.AccessFailedCount > 3)
                {
                    user.LockoutEnd = DateTime.UtcNow.AddMinutes(3);
                }

                await _useManager.UpdateAsync(user);
                return new ServerResponse(null, false, "Your password is incorrect");
            }
            user.AccessFailedCount = 0;
            await _useManager.UpdateAsync(user);

            bool isConfirmEmail = await _useManager.IsEmailConfirmedAsync(user);

            if (!isConfirmEmail)
            {
                return new ServerResponse(null, false, "Your account has not been verified, please verify before logging in");
            }

            bool isLocked = await _useManager.IsLockedOutAsync(user);

            if(isLocked)
            {
                return new ServerResponse(null, false, "Your account is locked, please try again later");
            }

            var userSignIn = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: true, lockoutOnFailure: true);

            if(!userSignIn.Succeeded)
            {
                return new ServerResponse(null, false, "Error please try again");
            }
            var roleLists =await _useManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roleLists);
            var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();
            TokenDto tokenData = new TokenDto(token, refreshToken);
            UserDto userData = _mapper.Map<ApplicationUser, UserDto>(user);
            LoginResponse loginResponse = new LoginResponse(userData, tokenData);
            RefreshToken refreshmodel = new RefreshToken();
            refreshmodel.Token = refreshToken;
            refreshmodel.UserId = user.Id;
            await _refreshTokenService.CreateRefreshTokenAsync(refreshmodel);
            return new ServerResponse(loginResponse, true, "Success");


        }

        public async Task<ServerResponse> RegisterAsync(RegisterRequest model)
        {
            var checkEmail = await _useManager.FindByEmailAsync(model.Email);
            if(checkEmail is not null)
            {
                return new ServerResponse(null, false, "Tài khoản đã tồi tại");
            }

            ApplicationUser user = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                NormalizedEmail = model.Email,
                CardId = model.CardId,
                PhoneNumber = model.PhoneNumber,
            };

            try
            {
                var result = await _useManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync(ROLES.CLIENT.ToString()).GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole(ROLES.CLIENT.ToString()));
                    }

                    await _useManager.AddToRoleAsync(user, ROLES.CLIENT.ToString());
                    var token = _jwtTokenGenerator.GenerateTokenByUserId(user.Id);
                    await _emailService.SendEmailConfirmAccountAsync(user.Email, token, "auth", "confirm-email");
                    return new ServerResponse(user, true, "Created");
                }
                else
                {
                    return new ServerResponse(null, false, result.Errors.FirstOrDefault()!.Description);
                }
            }catch(Exception ex)
            {
                return new ServerResponse(null, false, ex.Message.ToString());
            }
        }

        private async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            ApplicationUser? applicationUser = await _useManager.FindByEmailAsync(email);
            return applicationUser!;
        }

        public async Task<ServerResponse> ResetPasswordAsync(ResetPasswordRequest model)
        {
            if(model.ConfirmPassword != model.Password)
            {
                return new ServerResponse(null, false, "Password don't matching");
            }

            var user = await FindUserByEmailAsync(model.Email);
            if(user is null)
            {
                return new ServerResponse(null, false, "User don't exist");
            }
            var result = await _useManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (!result.Succeeded)
            {
                return new ServerResponse(null, false, "Change password is faild");
            }

            return new ServerResponse(null, true, "Change password successfull");
        }

        public async Task<ServerResponse> ChangePasswordAsync(ChangePasswordRequest model)
        {
            var user = await FindUserByEmailAsync(model.Email);
            if(user is null)
            {
                return new ServerResponse(null, false, "User don't exist");
            }
            bool isCheckPassword = await _useManager.CheckPasswordAsync(user, model.Password);
            if (!isCheckPassword)
            {
                return new ServerResponse(null, false, "Your password incorrect");
            }
            if(model.NewPassword != model.ConfirmNewPassword)
            {
                return new ServerResponse(null, false, "Password don't matching");
            }
            var result = await _useManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
            if (!result.Succeeded)
            {
                return new ServerResponse(null, false, "Change password faild");
            }
            return new ServerResponse(null, true, "Change password success");
        }

        public Task<ServerResponse> AssigRoleClaimAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ServerResponse> DeleteUserAsync(string email)
        {
            var user = await FindUserByEmailAsync(email);
            if(user is null)
            {
                return new ServerResponse(null, false, "User don't exist");
            }
            await _useManager.DeleteAsync(user);
            return new ServerResponse(null, true, "Delete user successfull");
        }
    }
}
