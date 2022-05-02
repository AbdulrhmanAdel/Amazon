namespace identity.JWT;

public struct JwtConfiguration
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public int ExpireInDays { get; set; }
    
}