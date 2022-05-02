namespace identity.EntitiesConfiguration;

public class EntityClassMapRegistration
{
    public static void Register()
    {
        UserMapping.RegisterApplicationUserMap();
    }
}