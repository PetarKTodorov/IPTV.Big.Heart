namespace IPTV.Big.Heart.Database.Models.Television
{
    using System;
    public class TelevisionStreamMapping : BaseModel
    {
        public Guid TelevisionId { get; set; }
        public Television Television { get; set; }

        public Guid StreamId { get; set; }
        public Stream Stream { get; set; }
    }
}
