namespace IPTV.Big.Heart.Database.Seed.Seeders.User
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    using IPTV.Big.Heart.Database.Models.User;
    using IPTV.Big.Heart.DTOs.BindingModels.User.Create;
    using IPTV.Big.Heart.Services.Database.User.Interfaces;
    using IPTV.Big.Heart.Services.Database.Location.Interfaces;
    using IPTV.Big.Heart.Database.Models.Location;

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
            string passwordSalt = this.Service.GeneratePasswordSalt();
            string passwordHash = this.Service.HashPassword(Constants.UsersPassword, passwordSalt);
            

            var userList = new List<CreateUserBindingModel>
            {
                new CreateUserBindingModel(Constants.AdminUsername, Constants.AdminEmail, passwordHash, passwordSalt, this.GetRandomCountryId()),
                new CreateUserBindingModel(Constants.UserUsername, Constants.UserEmail, passwordHash, passwordSalt, this.GetRandomCountryId())
            };

            this.ListOfDTOEntities = userList;
        }

        private Guid GetRandomCountryId()
        {
            var allCountries = this.countryService.GetAllAsync<Country>(false).GetAwaiter().GetResult().ToArray();

            int randomIndex = new Random().Next(0, allCountries.Length);

            Guid countryId = allCountries[randomIndex].Id;

            return countryId;
        }
    }
}
