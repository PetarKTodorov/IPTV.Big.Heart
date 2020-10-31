namespace IPTV.Big.Heart.Database.Models.Television
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class Television : BaseModel, IDable<string>
    {
        public Television()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Categories = new HashSet<TelevisionCategoryMapping>();
            this.Streams = new HashSet<TelevisionStreamMapping>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<TelevisionCategoryMapping> Categories { get; set; }

        public ICollection<TelevisionStreamMapping> Streams { get; set; }
    }
}
