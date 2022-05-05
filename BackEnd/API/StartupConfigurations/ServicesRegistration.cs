using identity;
using Persistance;

namespace api.StartupConfigurations;

public static class ServicesRegistration
{
    public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddHttpContextAccessor();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddIdentityService(configuration);
        services.AddDataService();
    }
}