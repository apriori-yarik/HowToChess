using Business.Dtos;
using Business.Dtos.User;
using Business.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly JWTSettingsDto _settingsDto;

        public AuthService(IUserRepository repository, JWTSettingsDto settingsDto)
        {
            _repository = repository;
            _settingsDto = settingsDto;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var users = await _repository.GetAllAsync<UserDtoWithId>(user => user.Email == email);

            if (users == null || users.Count == 0)
            {
                return null;
            }

            var user = users.FirstOrDefault();

            var isVerified = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!isVerified)
            {
                return null;
            }

            var token = GenerateToken(user);
            return token;
        }

        private string GenerateToken(UserDtoWithId user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settingsDto.Key));
            var credentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                issuer: _settingsDto.Issuer,
                audience: _settingsDto.Audience,
                expires: DateTime.Now.AddHours(int.Parse(_settingsDto.Expiration)),
                claims: GetClaims(user),
                signingCredentials: credentials);

            return tokenHandler.WriteToken(token);
        }

        private IEnumerable<Claim> GetClaims(UserDtoWithId user)
        {
            return new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
        }

        public async Task RegisterAsync(UserDto userDto)
        {
            userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            await _repository.CreateAsync(userDto);
        }
    }
}
