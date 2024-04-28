

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ParkingManagement.Application.Common.Interface.Authentication;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.DTOs.Authentication;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Authentication;
using ParkingManagement.Constracts.Helpers;
using ParkingManagement.Domain.Entities.Authetication;
using ParkingManagement.Infrastucture.Data;

namespace ParkingManagement.Infrastucture.Repos
{
    public class RefreshTokenService: IRefreshTokenService
    {

        private readonly ApplicationDbContext _context;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;
        public RefreshTokenService(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ServerResponse> CreateRefreshTokenAsync(RefreshToken model)
        {
            try
            {
                model.Id = Guid.NewGuid();
                model.isActive = true;
                model.IssuedAt = DateTime.UtcNow;
                model.ExpiresAt = DateTime.UtcNow.AddDays(3);

                await _context.RefreshTokens.AddAsync(model);
                await _context.SaveChangesAsync();
                return new ServerResponse(null, true,"Success");
            }
            catch (Exception ex)
            {
                return new ServerResponse(null, false, ex.Message.ToString());
            }

            
        }

        public async Task<ServerResponse> RefreshTokenAsync(RefreshTokenRequest model)
        {
           var checkUser = await _context.RefreshTokens.FirstOrDefaultAsync(r => r.Token == model.RefreshToken && r.UserId == model.UserId);
           if(checkUser is null)
           {
                return new ServerResponse(null, false, "Refresh token faild");
           }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user is null)
            {
                return new ServerResponse(null, false, "User don't exist");
            }
            if (IsExpired(checkUser.ExpiresAt))
            {
                return new ServerResponse(null, false, "Token is expired");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var accessToken =  _jwtTokenGenerator.GenerateToken(user, roles);
            var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();
            checkUser.Token = refreshToken;
            checkUser.IssuedAt = DateTime.UtcNow;
            checkUser.ExpiresAt = DateTime.UtcNow.AddDays(3);
            _context.RefreshTokens.Update(checkUser);
            await _context.SaveChangesAsync();

            TokenDto tokenData = new TokenDto(accessToken, refreshToken);
           

            return new ServerResponse(tokenData, true, "Refresh token success");
        }

        public Task<ServerResponse> UpdateRefreshTokenAsync(RefreshToken model)
        {
            throw new NotImplementedException();
        }

        private bool IsExpired(DateTime time)
        {
            return DateTime.UtcNow >= time; 
        }
    }
}
