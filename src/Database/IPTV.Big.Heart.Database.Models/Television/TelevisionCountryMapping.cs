namespace IPTV.Big.Heart.Database.Models.Television
{
    using System;

    using Location;

    public class TelevisionCountryMapping : BaseModel
    {
        public Guid TelevisionId { get; set; }
        public virtual Television Television { get; set; }

        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
