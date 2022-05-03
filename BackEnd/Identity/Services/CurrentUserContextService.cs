using System.Net.Http.Headers;
using DefaultNamespace;
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
        Enum.TryParse<UserLocale>(
            httpContextAccessor.HttpContext.Request.Headers[HeaderNames.AcceptLanguage].ToString(), out var locale);

        Locale = locale;
    }

    public Guid UserId { get; }
    public UserLocale Locale { get; }
}