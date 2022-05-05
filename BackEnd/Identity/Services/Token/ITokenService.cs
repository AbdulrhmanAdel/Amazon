using core.Identity.Entities;

namespace identity.Services.Token;

public interface ITokenService
{
    string GenerateToken(ApplicationUser user);
}