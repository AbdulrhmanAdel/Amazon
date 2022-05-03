using core.Identity.Entities;
using core.Identity.Models;

namespace core.Mappers;

public static class CurrentUserModelMapper
{
    public static CurrentUserModel MapApplicationUserToCurrentUserModel(this ApplicationUser user)
    {
        return new CurrentUserModel()
        {
            Id = user.Id,
            Email = user.Email,
            DisplayName = user.DisplayName
        };
    }
}