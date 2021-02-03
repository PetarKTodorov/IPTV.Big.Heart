namespace IPTV.Big.Heart.Database.Models.User
{
    using System;

    public class UserRoleMapping : BaseModel
    {
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
