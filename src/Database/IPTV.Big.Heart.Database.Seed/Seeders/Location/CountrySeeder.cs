namespace IPTV.Big.Heart.Database.Seed.Seeders.Location
{
    using System;
    using System.Collections.Generic;
    using IPTV.Big.Heart.Database.Models.Location;
    using IPTV.Big.Heart.DTOs.BindingModels.Location.Create;
    using IPTV.Big.Heart.Services.Database.Location.Interfaces;

    public class CountrySeeder : BaseSeeder<ICountryService, Country, CreateCountryBindingModel>
    {
        public CountrySeeder(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            
        }

        public override void GenerateList()
        {
            this.ListOfDTOEntities = new List<CreateCountryBindingModel>
            {
                new CreateCountryBindingModel(Constants.CountryName1),
                new CreateCountryBindingModel(Constants.CountryName2),
            };
        }
    }
}
