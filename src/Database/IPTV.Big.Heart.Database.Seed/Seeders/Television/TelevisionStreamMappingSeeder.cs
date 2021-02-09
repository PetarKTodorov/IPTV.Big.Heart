namespace IPTV.Big.Heart.Database.Seed.Seeders.Television
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    using IPTV.Big.Heart.Database.Models.Television;
    using IPTV.Big.Heart.DTOs.BindingModels.Television.Create;
    using IPTV.Big.Heart.Services.Database.Television.Interfaces;

    public class TelevisionStreamMappingSeeder : BaseSeeder<ITelevisionStreamMappingService, TelevisionStreamMapping, CreateTelevisionStreamMappingBindingModel>
    {
        private readonly IStreamService streamService;
        private readonly ITelevisionService televisionService;

        public TelevisionStreamMappingSeeder(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
            this.streamService = serviceProvider.GetRequiredService<IStreamService>();
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

            var allStreams = this.streamService.GetAllAsync()
                .GetAwaiter()
                .GetResult()
                .ToArray();

            var btvComedyStreamId = allStreams.FirstOrDefault(stream => stream.Path == Constants.Stream1).Id;
            var foxHdStreamId1 = allStreams.FirstOrDefault(stream => stream.Path == Constants.Stream2).Id;
            var foxHdStreamId2 = allStreams.FirstOrDefault(stream => stream.Path == Constants.Stream3).Id;
            var hboHdStreamId = allStreams.FirstOrDefault(stream => stream.Path == Constants.Stream4).Id;

            var televisionStreamMappingList = new List<CreateTelevisionStreamMappingBindingModel>
            {
                new CreateTelevisionStreamMappingBindingModel(btvComedyId, btvComedyStreamId),
                new CreateTelevisionStreamMappingBindingModel(foxHdId, foxHdStreamId1),
                new CreateTelevisionStreamMappingBindingModel(foxHdId, foxHdStreamId2),
                new CreateTelevisionStreamMappingBindingModel(hbo2HdId, hboHdStreamId),
            };

            this.ListOfDTOEntities = televisionStreamMappingList;
        }
    }
}
