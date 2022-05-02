using System.Text.RegularExpressions;

namespace core.Validators;

public static class EmailValidators
{
    public static bool IsValidEmailAddress(this string email)
    {
        return Regex.IsMatch(email, "");
    }
}