namespace IPTV.Big.Heart.Database.Seed.Seeders.Television
{
    using System;
    using System.Collections.Generic;

    using IPTV.Big.Heart.Database.Models.Television;
    using IPTV.Big.Heart.DTOs.BindingModels.Television.Create;
    using IPTV.Big.Heart.Services.Database.Television.Interfaces;

    public class StreamSeeder : BaseSeeder<IStreamService, Stream, CreateStreamBindingModel>
    {
        public StreamSeeder(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {

        }

        public override void GenerateList()
        {
            this.ListOfDTOEntities = new List<CreateStreamBindingModel>
            {
                new CreateStreamBindingModel(Constants.Stream1),
                new CreateStreamBindingModel(Constants.Stream2),
                new CreateStreamBindingModel(Constants.Stream3),
                new CreateStreamBindingModel(Constants.Stream4),
            };
        }
    }
}
