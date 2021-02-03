namespace IPTV.Big.Heart.Database.Models.Location
{
    using System.Collections.Generic;

    using User;
    using Television;
    using Interfaces;

    public class Country : BaseModel
    {
        public Country()
        {
            this.Televisions = new HashSet<TelevisionCountryMapping>();
            this.Users = new HashSet<User>();
        }

        public string Name { get; set; }

        public ICollection<TelevisionCountryMapping> Televisions { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
