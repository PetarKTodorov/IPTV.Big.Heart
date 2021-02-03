﻿namespace IPTV.Big.Heart.Database.Models.User
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Location;

    public class User : BaseModel
    {
        public User()
        {
            this.Roles = new HashSet<UserRoleMapping>();
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public bool IsBanned { get; set; }

        public DateTime? StartBannedDate { get; set; }

        public DateTime? EndBannedDate { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<UserRoleMapping> Roles { get; set; }
    }
}
