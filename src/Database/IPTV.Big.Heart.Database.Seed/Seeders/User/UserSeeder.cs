namespace IPTV.Big.Heart.Database.Seed.Seeders.User
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    using IPTV.Big.Heart.Database.Models.User;
    using IPTV.Big.Heart.DTOs.BindingModels.User;
    using IPTV.Big.Heart.Services.Database.User.Interfaces;
    using IPTV.Big.Heart.Services.Database.Location.Interfaces;

    public class UserSeeder : BaseSeeder<IUserService, User, CreateUserBindingModel>
    {
        private readonly ICountryService countryService;

        public UserSeeder(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
            this.countryService = serviceProvider.GetRequiredService<ICountryService>();
        }

        public override void GenerateList()
        {
            string passwordHash = this.Service.HashPassword(Constants.UsersPassword);

            var userList = new List<CreateUserBindingModel>
            {
                new CreateUserBindingModel(Constants.AdminUsername, Constants.AdminEmail, passwordHash, this.GetRandomCountryId()),
                new CreateUserBindingModel(Constants.UserUsername, Constants.UserEmail, passwordHash, this.GetRandomCountryId())
            };

            this.ListOfDTOEntities = userList;
        }

        private Guid GetRandomCountryId()
        {
            var allCountries = this.countryService.GetAllAsync(false).GetAwaiter().GetResult().ToArray();

            int randomIndex = new Random().Next(0, allCountries.Length);

            Guid countryId = allCountries[randomIndex].Id;

            return countryId;
        }
    }
}
