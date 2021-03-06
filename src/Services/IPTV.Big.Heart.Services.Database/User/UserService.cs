﻿namespace IPTV.Big.Heart.Services.Database.User
{
    using System;
    using System.Security.Cryptography;
    using System.Linq;

    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.User;
    using System.Threading.Tasks;
    using IPTV.Big.Heart.DTOs.BindingModels.User;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Extensions.Options;
    using IPTV.Big.Heart.Common;
    using Microsoft.EntityFrameworkCore;
    using IPTV.Big.Heart.DTOs.BindingModels.User.Create;

    public class UserService : BaseDatabaseService<User>, IUserService
    {
        private readonly ApplicationSettings appSettings;
        private readonly IRoleService roleService;
        private readonly IUserRoleMappingService userRoleMappingService;

        public UserService(IRepository<User> repositary, 
            IMapper mapper, 
            IOptions<ApplicationSettings> appSettings, 
            IRoleService roleService,
            IUserRoleMappingService userRoleMappingService) 
            : base(repositary, mapper)
        {
            this.appSettings = appSettings.Value;
            this.userRoleMappingService = userRoleMappingService;
            this.roleService = roleService;
        }

        public async Task<string> Login(LoginBindingModel model)
        {
            var user = this.GetUserByUsername(model.Username);

            if (user == null)
            {
                return null;
            }

            string passwordHash = this.HashPassword(model.Password, user.PasswordSalt);
            bool isPasswordsNotMatching = (passwordHash == user.PasswordHash) == false;

            if (isPasswordsNotMatching)
            {
                return null;
            }

            string token = this.GenerateJwtToken(user);

            return token;
        }

        public User GetUserByEmail(string email)
        {
            var users = this.GetAllAsync<User>().GetAwaiter().GetResult();

            var user = users.SingleOrDefault(u => u.Email == email);

            return user;
        }

        public User GetUserByUsername(string username)
        {
            var users = this.GetAll();

            var user = users
                .Include(o => o.Roles)
                .ThenInclude(o => o.Role)
                .SingleOrDefault(u => u.Username == username);

            return user;
        }

        public string HashPassword(string password, string passwordSalt)
        {
            var salt = Encoding.ASCII.GetBytes(passwordSalt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public string GeneratePasswordSalt()
        {
            byte[] saltArray = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltArray);
            }

            string salt = Encoding.UTF8.GetString(saltArray);

            return salt;
        }

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 2 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.ApiSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                    new Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<string> Register(RegisterBindingModel model)
        {
            var user = this.Mapper.Map<CreateUserBindingModel>(model);

            string passwordSalt = this.GeneratePasswordSalt();
            string passwordHash = this.HashPassword(model.Password, passwordSalt);


            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            var registeredUser = await this.CreateAsync(user);

            if (registeredUser == null)
            {
                return $"Invalid User";
            }

            var role = this.roleService.GetRoleByName(GlobalConstants.UserRole);

            var userRoleMapping = new CreateUserRoleMappingBindingModel(registeredUser.Id, role.Id);

            await this.userRoleMappingService.CreateAsync(userRoleMapping);

            return $"Successfully registered with username: {registeredUser.Username}.";
        }
    }
}
