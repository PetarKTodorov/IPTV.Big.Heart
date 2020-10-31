namespace IPTV.Big.Heart.Database.Models.Television
{
    public class TelevisionStreamMapping : BaseModel
    {
        public string TelevisionId { get; set; }
        public Television Television { get; set; }

        public string StreamId { get; set; }
        public Stream Stream { get; set; }
    }
}
