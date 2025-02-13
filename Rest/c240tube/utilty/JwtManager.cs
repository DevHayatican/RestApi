using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace c240tube.utilty
{
    public class JwtManager
    {
        private readonly string salt = "cf83e1357eefb8bdf1542850d66d8007d620e4050b5715dc83f4a921d36ce9ce47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e";

        private readonly TimeSpan expirationTime = TimeSpan.FromMinutes(90);

        public string CreateToken(long id)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(salt);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("id",id.ToString()),
                        new Claim("kendimeNot","Fena bir sey oldu bu be")
                    }),
                    Expires = DateTime.UtcNow.Add(expirationTime),
                    Issuer = "c240",
                    IssuedAt = DateTime.UtcNow,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception exception)
            {
                throw new Exception("Token olusturulurken HATA !!!!");
            }
        }

        public string ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(salt);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "c240",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ValidateAudience = false,

                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                //return jwtToken.Subject;

                return jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            }
            catch (Exception e)
            {
                throw new Exception("Token acilirken hata...");
            }
        }
    }
}
