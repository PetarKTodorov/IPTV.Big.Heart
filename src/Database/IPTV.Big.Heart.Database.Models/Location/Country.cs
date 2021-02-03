namespace IPTV.Big.Heart.Database.Models.Location
{
    using System.Collections.Generic;

    using User;
    using Television;

    public class Country : BaseModel
    {
        public Country()
        {
            this.Televisions = new HashSet<TelevisionCountryMapping>();
            this.Users = new HashSet<User>();
        }

        public string Name { get; set; }

        public virtual ICollection<TelevisionCountryMapping> Televisions { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
