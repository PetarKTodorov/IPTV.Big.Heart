namespace IPTV.Big.Heart.DTOs.BindingModels.Television
{
    using System;

    public class CreateTelevisionCountryMappingBindingModel
    {
        public CreateTelevisionCountryMappingBindingModel(Guid televisionId, Guid countryId)
        {
            this.TelevisionId = televisionId;
            this.CountryId = countryId;
        }

        public Guid TelevisionId { get; set; }

        public Guid CountryId { get; set; }
    }
}
