using System.Net.Http.Headers;
using Core.Identity.Enums;
using Core.Identity.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace identity.Services;

public class CurrentUserContextService : ICurrentUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        var authorizationHeader = httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization];
        if (string.IsNullOrWhiteSpace(authorizationHeader.ToString())) return;
        UserId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst(claim => claim.Type == "Id").Value);
    }

    public Guid UserId { get; }

    public UserLocale Locale =>
        Enum.Parse<UserLocale>(_httpContextAccessor.HttpContext.Request.Headers[HeaderNames.AcceptLanguage].ToString());

    public bool IsAdmin =>
        bool.Parse(_httpContextAccessor.HttpContext.User.FindFirst(claim => claim.Type == "IsAdmin").Value);
}