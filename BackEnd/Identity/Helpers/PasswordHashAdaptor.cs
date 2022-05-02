using System.Runtime.CompilerServices;

namespace identity.Helpers;

public class PasswordHashAdaptor
{
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public static bool VerifyHash(string password, string hash)
    {
        try
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }
        catch
        {
            return false;
        }
    }
}