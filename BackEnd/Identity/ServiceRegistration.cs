using System.Text;
using Core.Identity.Services;
using DefaultNamespace;
using identity.EntitiesConfiguration;
using identity.Services;
using identity.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace identity;

public static class ServiceRegistration
{
    public static void AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICurrentUserContext, CurrentUserContextService>();


        #region JWT
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)    
            .AddJwtBearer(options =>    
            {    
                options.TokenValidationParameters = new TokenValidationParameters    
                {    
                    ValidateIssuer = true,    
                    ValidateAudience = true,    
                    ValidateLifetime = true,    
                    ValidateIssuerSigningKey = true,    
                    ValidIssuer = configuration["Jwt:Issuer"],    
                    ValidAudience = configuration["Jwt:Issuer"],    
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))    
                };    
            });    
        

        #endregion
        #region Mongo
        BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
        ConventionRegistry.Register("camelCase", conventionPack, t => true);

        services.AddSingleton<IMongoClient>(_ =>
        {
            var cn = configuration["Mongo:ConnectionString"];
            return new MongoClient(cn);
        });
        #endregion

        #region Class Maps

        EntityClassMapRegistration.Register();

        #endregion
    }
}