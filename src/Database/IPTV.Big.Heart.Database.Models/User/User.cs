namespace IPTV.Big.Heart.Database.Models.User
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Location;

    public class User : BaseModel, IDable<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<UserRoleMapping>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string PasswardSalt { get; set; }

        public bool IsBanned { get; set; }

        public DateTime? StartBannedDate { get; set; }

        public DateTime? EndBannedDate { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<UserRoleMapping> Roles { get; set; }
    }
}
