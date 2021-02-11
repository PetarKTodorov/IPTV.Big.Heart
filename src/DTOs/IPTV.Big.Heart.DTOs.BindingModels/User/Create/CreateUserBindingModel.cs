namespace IPTV.Big.Heart.DTOs.BindingModels.User.Create
{
    using System;

    public class CreateUserBindingModel
    {
        public CreateUserBindingModel()
        {
            this.IsBanned = false;
            this.IsEmailConfirmed = false;
        }

        public CreateUserBindingModel(string username, string email, string passwordHash, string passwordSalt, Guid countryId)
            : this()
        {
            this.Username = username;
            this.Email = email;
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
            this.CountryId = countryId;
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string PasswordSalt { get; set; }


        public string PasswordHash { get; set; }

        public bool IsBanned { get; set; }

        public Guid CountryId { get; set; }
    }
}
