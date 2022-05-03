using core.Identity.Entities;
using core.Identity.Models;

namespace core.Mappers;

public static class LoggedInUserMapper
{
    public static LoggedInUserModel MapApplicationUserToLoggedInUser(this ApplicationUser user, string token)
    {
        return new LoggedInUserModel()
        {
            Id = user.Id,
            Token = token,
            Email = user.Email,
            DisplayName = user.DisplayName
        };
    }
}