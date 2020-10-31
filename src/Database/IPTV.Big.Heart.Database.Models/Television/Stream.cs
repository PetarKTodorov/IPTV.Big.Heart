namespace IPTV.Big.Heart.Database.Models.Television
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class Stream : BaseModel, IDable<string>
    {
        public Stream()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Televisions = new HashSet<TelevisionStreamMapping>();
        }

        public string Id { get; set; }

        public string Path { get; set; }

        public ICollection<TelevisionStreamMapping> Televisions { get; set; }
    }
}
