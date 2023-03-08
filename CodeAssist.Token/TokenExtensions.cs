using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodeAssist.Token
{
    public static class TokenExtensions
    {
        /// <summary>
        /// Converts jwtToken to JsonString
        /// </summary>
        /// <param name="jwtToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string ConvertJwtTokenToJson(this string jwtToken)
        {
            var parts = jwtToken.Split('.');

            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid JWT token");
            }

            var decodedBytes = Convert.FromBase64String(parts[1].Replace("-", "+").Replace("_", "/"));
            var json = System.Text.Encoding.UTF8.GetString(decodedBytes);

            return JsonConvert.SerializeObject(JsonConvert.DeserializeObject(json), Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Extract Claims from jwt Token
        /// </summary>
        /// <param name="jwtToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ClaimsPrincipal ExtractClaims(this string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();

            return handler.ReadToken(jwtToken) is not JwtSecurityToken token ? throw new ArgumentException("Invalid JWT token") : new ClaimsPrincipal(new ClaimsIdentity(token.Claims));
        }

        /// <summary>
        /// Validates JwtToken and creates ClaimsPrincipal
        /// </summary>
        /// <param name="token"></param>
        /// <param name="secretKey"></param>
        /// <returns>ClaimsPrincipal</returns>
        public static ClaimsPrincipal? ValidateJwtToken(this string token, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                return new ClaimsPrincipal((IEnumerable<ClaimsIdentity>)new JwtSecurityTokenHandler().ReadJwtToken(token));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Generates token from ClaimsIdentity
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="secretKey"></param>
        /// <param name="expiryInMinutes"></param>
        /// <returns>String token</returns>
        public static string GenerateJwtToken(this ClaimsIdentity identity, string secretKey, int expiryInMinutes = 60)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddMinutes(expiryInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Generates a JWT token for the provided identity, secret key, and options
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="secretKey"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string GenerateJwtToken(this ClaimsIdentity identity, string secretKey, JwtOptions options)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = options.ExpiryTime,
                NotBefore = options.NotBeforeTime,
                IssuedAt = options.IssuedAtTime,
                Audience = options.Audience,
                Issuer = options.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), options.SignatureAlgorithm)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Adds a single claim to the provided identity
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public static void AddClaim(this ClaimsIdentity identity, string type, string value)
        {
            identity.AddClaim(new Claim(type, value));
        }

        /// <summary>
        /// Adds a list of claims to the provided identity
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="claims"></param>
        public static void AddClaims(this ClaimsIdentity identity, IEnumerable<Claim> claims)
        {
            identity.AddClaims(claims);
        }

        /// <summary>
        /// Gets the value of the specified claim type from the provided identity
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string? GetClaimValue(this ClaimsIdentity identity, string type)
        {
            return identity.FindFirst(type)?.Value;
        }
    }
}