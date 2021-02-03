namespace IPTV.Big.Heart.Database.Models.Television
{
    using System;

    public class TelevisionCategoryMapping : BaseModel
    {
        public Guid TelevisionId { get; set; }
        public virtual Television Television { get; set; }

        public Guid CategoryId { get; set; }
        public virtual TelevisionCategory Category { get; set; }
    }
}
