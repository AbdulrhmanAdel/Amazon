

using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Persistance.Mongo.ClassMaps;
using persistance.Mongo.Services;
using persistance.Seed;

namespace Persistance;

public static class ServiceRegistration
{
    public static void AddDataService(this IServiceCollection service)
    {
        service.AddScoped<IProductService, ProductService>();
        
        ClassMaps.Register();
        service.AddScoped<SeedService>();
    }
    
}