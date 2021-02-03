namespace IPTV.Big.Heart.Database.Models.Television
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class Stream : BaseModel
    {
        public Stream()
        {
            this.Televisions = new HashSet<TelevisionStreamMapping>();
        }

        public string Path { get; set; }

        public ICollection<TelevisionStreamMapping> Televisions { get; set; }
    }
}
