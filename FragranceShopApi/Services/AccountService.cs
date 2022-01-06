using AutoMapper;
using Data;
using Data.Entities;
using FragranceShopApi.Exceptions;
using FragranceShopApi.Models.Account;
using FragranceShopApi.Services.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace FragranceShopApi.Services
{
    public interface IAccountService : IScopedService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly PerfumeDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(
            IMapper mapper,
            PerfumeDbContext context,
            IPasswordHasher<User> passwordHasher,
            AuthenticationSettings authenticationSettings)
        {
            _mapper = mapper;
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);

            if (user is null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim(ClaimTypes.Email, user.Email),
            };

            if (user.DateOfBirth.HasValue)
            {
                claims.Add(new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
            }

            if(!string.IsNullOrEmpty(user.Nationality))
            {
                claims.Add(new Claim("Nationality", user.Nationality));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(
                _authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = _mapper.Map<User>(dto);

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;

            _context.Add(newUser);
            _context.SaveChanges();
        }
    }
}
