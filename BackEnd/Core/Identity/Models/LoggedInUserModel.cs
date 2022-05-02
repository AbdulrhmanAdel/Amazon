namespace core.Identity.Models;

public class LoggedInUserModel
{
    public Guid Id { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}