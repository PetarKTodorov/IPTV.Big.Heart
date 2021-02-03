namespace IPTV.Big.Heart.Database.Models.Television
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class Television : BaseModel
    {
        public Television()
        {
            this.Categories = new HashSet<TelevisionCategoryMapping>();
            this.Streams = new HashSet<TelevisionStreamMapping>();
            this.Countries = new HashSet<TelevisionCountryMapping>();
        }

        public string Name { get; set; }

        public virtual ICollection<TelevisionCountryMapping> Countries { get; set; }

        public virtual ICollection<TelevisionCategoryMapping> Categories { get; set; }

        public virtual ICollection<TelevisionStreamMapping> Streams { get; set; }
    }
}
