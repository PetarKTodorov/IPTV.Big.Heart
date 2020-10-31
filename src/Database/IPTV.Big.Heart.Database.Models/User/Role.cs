namespace IPTV.Big.Heart.Database.Models.User
{
    using System.Collections.Generic;

    using Interfaces;

    public class Role : BaseModel, IDable<int>
    {
        public Role()
        {
            this.Users = new HashSet<UserRoleMapping>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserRoleMapping> Users { get; set; }
    }
}
