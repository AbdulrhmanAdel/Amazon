﻿using core.Identity.Dto;
using Core.Identity.Services;
using core.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Identity;

public class UserController : BaseV1ApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("SignUp")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUpAsync([FromForm] SignUpUserDto signUpUserDto)
    {
        var result = await _userService.SignUpAsync(signUpUserDto);

        if (result.Success)
        {
            return ItemResult(result.Payload);
        }

        return InvalidRequest(result.Messages);
    }

    [HttpPost("LogIn")]
    [AllowAnonymous]
    public async Task<IActionResult> LogInAsync([FromBody] LoggedInUserDto loggedInUserDto)
    {
        var result = await _userService.LogInAsync(loggedInUserDto);

        if (result.Success)
        {
            return ItemResult(result.Payload);
        }

        return InvalidRequest(result.Messages);
    }

    [HttpGet("IsEmailExists")]
    [AllowAnonymous]
    public async Task<IActionResult> IsEmailExistsAsync(string email)
    {
        if (!email.IsValidEmailAddress())
        {
            return InvalidRequest("Invalid Email");
        }

        var result = await _userService.IsEmailExistsAsync(email);
        return ItemResult(result);
    }
}