namespace IPTV.Big.Heart.Database.Seed.Seeders.Television
{
    using System;
    using System.Collections.Generic;

    using IPTV.Big.Heart.Database.Models.Television;
    using IPTV.Big.Heart.DTOs.BindingModels.Television.Create;
    using IPTV.Big.Heart.Services.Database.Television.Interfaces;

    public class TelevisionSeeder : BaseSeeder<ITelevisionService, Television, CreateTelevisionBindingModel>
    {
        public TelevisionSeeder(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        public override void GenerateList()
        {
            this.ListOfDTOEntities = new List<CreateTelevisionBindingModel>
            {
                new CreateTelevisionBindingModel(Constants.Television1),
                new CreateTelevisionBindingModel(Constants.Television2),
                new CreateTelevisionBindingModel(Constants.Television3),
            };
        }
    }
}
