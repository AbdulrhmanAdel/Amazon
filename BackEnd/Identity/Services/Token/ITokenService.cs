namespace identity.Services.Token;

public interface ITokenService
{
    string GenerateToken(Guid userId);
}