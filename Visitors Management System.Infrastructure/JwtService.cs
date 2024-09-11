﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Visitors_Management_System.Domain.Entities;

namespace Visitors_Management_System.Infrastructure
{
	public class JwtService : IJwtService
	{
		private readonly IConfiguration _config;

		public JwtService(IConfiguration config)
		{
			_config = config;
		}

		public string GenerateToken(User user, IList<string> roles)
		{
			var tokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value);

			var claimList = new List<Claim>
		{
			new(ClaimTypes.NameIdentifier, user.Id),
			new(JwtRegisteredClaimNames.Sub, user.Id),
			new(JwtRegisteredClaimNames.Name, $"{user.FirstName} {user.LastName}"),
			new(JwtRegisteredClaimNames.Email, user.Email!)
		};
			claimList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));


			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Audience = _config.GetSection("JWT:Audience").Value,
				Issuer = _config.GetSection("JWT:Issuer").Value,
				Subject = new ClaimsIdentity(claimList),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials =
					new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
		}
	}
}
