using core.Identity.Entities;
using identity.Constants.FieldsMaps;
using MongoDB.Bson.Serialization;

namespace identity.EntitiesConfiguration;

public class UserMapping
{
    public static void RegisterApplicationUserMap()
    {
        BsonClassMap.RegisterClassMap<ApplicationUser>(user =>
        {
            user.AutoMap();
            user.MapIdField(u => u.Id);
            user.MapProperty(u => u.DisplayName).SetElementName(ApplicationUserFields.DisplayName);
            user.MapProperty(u => u.PasswordHash).SetElementName(ApplicationUserFields.PasswordHash);
        });
    }
}