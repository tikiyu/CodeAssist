using Microsoft.IdentityModel.Tokens;

namespace CodeAssist.Token
{
    public class JwtOptions
    {
        public DateTime ExpiryTime { get; set; } = DateTime.UtcNow.AddMinutes(60);
        public DateTime NotBeforeTime { get; set; } = DateTime.UtcNow;
        public DateTime IssuedAtTime { get; set; } = DateTime.UtcNow;
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SignatureAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
    }
}