namespace IPTV.Big.Heart.Database.Models.Television
{
    using System;
    public class TelevisionStreamMapping : BaseModel
    {
        public Guid TelevisionId { get; set; }
        public virtual Television Television { get; set; }

        public Guid StreamId { get; set; }
        public virtual Stream Stream { get; set; }
    }
}
