namespace IPTV.Big.Heart.Database.Models.Television
{
    using Location;

    public class TelevisionCountryMapping : BaseModel
    {
        public string TelevisionId { get; set; }
        public Television Television { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
