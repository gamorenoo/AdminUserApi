using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace AdminUserApi.Application
{
    /// <summary>
    /// Servicio de aplicacion para manejo del token
    /// </summary>
    public class JwtAuthAppService
    {
        #region Properties
        /// <summary>
        /// llave
        /// </summary>
        private readonly string _key;
        #endregion

        #region Build
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="key"></param>
        public JwtAuthAppService(string key)
        {
            _key = key;
        }
        #endregion

        public string Authenticate(string username, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
