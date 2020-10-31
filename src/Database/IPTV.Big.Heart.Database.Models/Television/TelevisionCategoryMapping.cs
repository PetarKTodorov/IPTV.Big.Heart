namespace IPTV.Big.Heart.Database.Models.Television
{
    public class TelevisionCategoryMapping : BaseModel
    {
        public string TelevisionId { get; set; }
        public Television Television { get; set; }

        public int CategoryId { get; set; }
        public TelevisionCategory Category { get; set; }
    }
}
