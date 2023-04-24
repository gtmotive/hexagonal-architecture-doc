using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using GtMotive.Estimate.Microservice.ApplicationCore.Identity.Models;
using GtMotive.Estimate.Microservice.Domain.Entities.Auth;
using Microsoft.IdentityModel.Tokens;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Common
{
    /// <summary>
    /// AuthHelper.
    /// </summary>
    public static class AuthHelper
    {
        /// <summary>
        /// GenerateJwt.
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="roles">Roles.</param>
        /// <param name="vehiclesInfo">VehiclesInfo.</param>
        /// <param name="jwtSettings">jwtSettings.</param>
        /// <returns>jwt token.</returns>
        public static string GenerateJwt(User user, IList<string> roles, IList<string> vehiclesInfo, JwtSettings jwtSettings)
        {
            if (user == null || jwtSettings == null)
            {
                return string.Empty;
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("ReservationsInfo", string.Join(", ", vehiclesInfo.ToArray()))
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
