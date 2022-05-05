

using Core.Identity.Enums;

namespace Core.Identity.Services
{
    public interface ICurrentUserContext
    {
        public Guid UserId { get; }
        public UserLocale Locale { get; }
        public bool IsAdmin { get; }
    }
}