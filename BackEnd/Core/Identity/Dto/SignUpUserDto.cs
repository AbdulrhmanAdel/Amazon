namespace core.Identity.Dto;

public class SignUpUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string DisplayName { get; set; }
}