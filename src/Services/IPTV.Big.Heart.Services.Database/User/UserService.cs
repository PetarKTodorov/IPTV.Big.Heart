namespace IPTV.Big.Heart.Services.Database.User
{
    using System;
    using System.Security.Cryptography;

    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.User;

    public class UserService : BaseDatabaseService<User>, IUserService
    {
        public UserService(IRepositary<User> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {

        }

        public string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashedPassword;
        }
    }
}
