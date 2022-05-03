using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Core.Common;
using core.Identity.Dto;
using core.Identity.Entities;
using core.Identity.Models;
using Core.Identity.Services;
using core.Mappers;
using core.Validators;
using identity.Constants;
using identity.Constants.FieldsMaps;
using identity.Helpers;
using identity.Services.Token;
using MongoDB.Bson;
using MongoDB.Driver;

namespace identity.Services;

public class UserService : IUserService
{
    private readonly ITokenService _tokenService;
    private readonly IMongoCollection<BsonDocument> _usersCollection;

    public UserService(IMongoClient mongoClient, ITokenService tokenService)
    {
        _tokenService = tokenService;
        _usersCollection = mongoClient.GetDatabase(MongoDatabaseNames.ECommerce)
            .GetCollection<BsonDocument>(MongoCollectionNames.Users);
    }

    public async Task<PayloadedServiceResult<LoggedInUserModel>> LogInAsync(LoggedInUserDto loggedInUserDto)
    {
        var serviceResult = new PayloadedServiceResult<LoggedInUserModel>();
        var user = await GetUserAsync(ApplicationUserFields.Email, loggedInUserDto.Email);
        if (user == null ||
            !PasswordHashAdaptor.VerifyHash(loggedInUserDto.Password, user.PasswordHash))
        {
            serviceResult.AddError("InValid Email Or Password");
            return serviceResult;
        }
        serviceResult.Payload = user.MapApplicationUserToLoggedInUser(_tokenService.GenerateToken(user.Id));
        return serviceResult;
    }

    public async Task<PayloadedServiceResult<LoggedInUserModel>> SignUpAsync(SignUpUserDto signUpUserDto)
    {
        var serviceResult = new PayloadedServiceResult<LoggedInUserModel>();
        if (signUpUserDto.Password != signUpUserDto.ConfirmPassword)
        {
            serviceResult.AddError("Password and confirm password should be the same");
            return serviceResult;
        }

        if (!Regex.IsMatch(signUpUserDto.Password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"))
        {
            serviceResult.AddError("Invalid Password");
            return serviceResult;
        }

        if (await IsEmailExistsHelperAsync(signUpUserDto.Email))
        {
            serviceResult.AddError("Invalid email");
            return serviceResult;
        }

        var user = new ApplicationUser()
        {
            Id = Guid.NewGuid(),
            Email = signUpUserDto.Email,
            PasswordHash = PasswordHashAdaptor.HashPassword(signUpUserDto.Password),
            DisplayName = signUpUserDto.DisplayName
        };
        await _usersCollection.InsertOneAsync(user.ToBsonDocument());
        serviceResult.Payload = user.MapApplicationUserToLoggedInUser(_tokenService.GenerateToken(user.Id));

        return serviceResult;
    }
    
    public async Task<PayloadedServiceResult<CurrentUserModel>> GetCurrentUserAsync(Guid userId)
    {
        var user = await GetUserAsync(CommonFields.MongoId, userId);
        return new PayloadedServiceResult<CurrentUserModel>()
        {
            Payload = user.MapApplicationUserToCurrentUserModel()
        };
    }

    private async Task<ApplicationUser> GetUserAsync<T>(string key, T value)
    {
        using var cursor =
            await _usersCollection.FindAsync(Builders<BsonDocument>.Filter.Eq(key, value), new FindOptions<BsonDocument, ApplicationUser>());

        return await cursor.FirstOrDefaultAsync();
    }
    public async Task<bool> IsEmailExistsAsync(string email)
    {
        if (email.IsValidEmailAddress())
        {
            return await IsEmailExistsHelperAsync(email);
        }

        return false;
    }

    private async Task<bool> IsEmailExistsHelperAsync(string email)
    {
        using var cursor =
            await _usersCollection.FindAsync(Builders<BsonDocument>.Filter.Eq(ApplicationUserFields.Email, email));
        return await cursor.AnyAsync();
    }
}