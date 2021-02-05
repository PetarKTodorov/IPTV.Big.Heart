namespace IPTV.Big.Heart.Database.Seed.Seeders.Television
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    using IPTV.Big.Heart.Database.Models.Television;
    using IPTV.Big.Heart.DTOs.BindingModels.Television;
    using IPTV.Big.Heart.Services.Database.Television.Interfaces;
    using IPTV.Big.Heart.Services.Database.Location.Interfaces;

    public class TelevisionCountryMappingSeeder : BaseSeeder<ITelevisionCountryMappingService, TelevisionCountryMapping, CreateTelevisionCountryMappingBindingModel>
    {

        private readonly ICountryService countryService;
        private readonly ITelevisionService televisionService;

        public TelevisionCountryMappingSeeder(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
            this.countryService = serviceProvider.GetRequiredService<ICountryService>();
            this.televisionService = serviceProvider.GetRequiredService<ITelevisionService>();
        }

        public override void GenerateList()
        {
            var allTelevisions = this.televisionService.GetAllAsync()
                .GetAwaiter()
                .GetResult()
                .ToArray();

            var btvComedyId = allTelevisions.FirstOrDefault(television => television.Name == Constants.Television1).Id;
            var foxHdId = allTelevisions.FirstOrDefault(television => television.Name == Constants.Television2).Id;
            var hbo2HdId = allTelevisions.FirstOrDefault(television => television.Name == Constants.Television3).Id;

            var allCountries = this.countryService.GetAllAsync()
                .GetAwaiter()
                .GetResult()
                .ToArray();

            var bulgariaId = allCountries.FirstOrDefault(country => country.Name == Constants.CountryName1).Id;
            var usaId = allCountries.FirstOrDefault(country => country.Name == Constants.CountryName2).Id;

            var televisionCountryMappingList = new List<CreateTelevisionCountryMappingBindingModel>
            {
                new CreateTelevisionCountryMappingBindingModel(btvComedyId, bulgariaId),
                new CreateTelevisionCountryMappingBindingModel(foxHdId, usaId),
                new CreateTelevisionCountryMappingBindingModel(hbo2HdId, usaId),
            };

            this.ListOfDTOEntities = televisionCountryMappingList;
        }
    }
}
