namespace core.Identity.Models;

public class CurrentUserModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string DisplayName { get; set; }
}