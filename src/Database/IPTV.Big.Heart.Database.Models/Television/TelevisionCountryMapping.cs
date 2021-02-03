namespace IPTV.Big.Heart.Database.Models.Television
{
    using System;

    using Location;

    public class TelevisionCountryMapping : BaseModel
    {
        public Guid TelevisionId { get; set; }
        public Television Television { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }
}
