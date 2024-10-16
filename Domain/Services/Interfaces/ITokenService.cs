using API.DTOs;
using Domain.Entities;


namespace Domain.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        RefreshTokenDto GenerateRefreshToken();
    }
}
