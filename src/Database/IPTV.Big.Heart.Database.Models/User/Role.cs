namespace IPTV.Big.Heart.Database.Models.User
{
    using System.Collections.Generic;

    using Interfaces;

    public class Role : BaseModel
    {
        public Role()
        {
            this.Users = new HashSet<UserRoleMapping>();
        }

        public string Name { get; set; }

        public virtual ICollection<UserRoleMapping> Users { get; set; }
    }
}
