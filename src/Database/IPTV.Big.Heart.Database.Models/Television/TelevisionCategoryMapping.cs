namespace IPTV.Big.Heart.Database.Models.Television
{
    using System;

    public class TelevisionCategoryMapping : BaseModel
    {
        public Guid TelevisionId { get; set; }
        public Television Television { get; set; }

        public Guid CategoryId { get; set; }
        public TelevisionCategory Category { get; set; }
    }
}
