using Core.Common;
using core.Identity.Dto;
using core.Identity.Models;

namespace Core.Identity.Services;

public interface IUserService
{
    Task<PayloadedServiceResult<LoggedInUserModel>> LogInAsync(LoggedInUserDto loggedInUserDto);
    Task<PayloadedServiceResult<LoggedInUserModel>> SignUpAsync(SignUpUserDto signUpUserDto);
    Task<bool> IsEmailExistsAsync(string email);
    Task<PayloadedServiceResult<CurrentUserModel>> GetCurrentUserAsync(Guid userId);
}