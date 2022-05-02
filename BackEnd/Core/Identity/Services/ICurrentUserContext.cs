namespace DefaultNamespace
{
    public interface ICurrentUserContext
    {
        public Guid UserId { get; }
        public UserLocale Locale { get; }
    }
}