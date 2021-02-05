namespace IPTV.Big.Heart.Database.Seed.Seeders.Television
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    using IPTV.Big.Heart.Database.Models.Television;
    using IPTV.Big.Heart.DTOs.BindingModels.Television;
    using IPTV.Big.Heart.Services.Database.Television.Interfaces;

    public class TelevisionCategoryMappingSeeder : BaseSeeder<ITelevisionCategoryMappingService, TelevisionCategoryMapping, CreateTelevisionCategoryMappingBindingModel>
    {
        private readonly ITelevisionCategoryService televisionCategoryService;
        private readonly ITelevisionService televisionService;

        public TelevisionCategoryMappingSeeder(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            this.televisionCategoryService = serviceProvider.GetRequiredService<ITelevisionCategoryService>();
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

            var allTelevisionCategories = this.televisionCategoryService.GetAllAsync()
                .GetAwaiter()
                .GetResult()
                .ToArray();

            var comedyCategoryId = allTelevisionCategories.FirstOrDefault(televisionCategory => televisionCategory.Name == Constants.TelevisionCategory1).Id;
            var documentaryCategoryId = allTelevisionCategories.FirstOrDefault(televisionCategory => televisionCategory.Name == Constants.TelevisionCategory2).Id;
            var actionCategoryId = allTelevisionCategories.FirstOrDefault(televisionCategory => televisionCategory.Name == Constants.TelevisionCategory3).Id;

            var televisionCategoryMappingList = new List<CreateTelevisionCategoryMappingBindingModel>
            {
                new CreateTelevisionCategoryMappingBindingModel(btvComedyId, comedyCategoryId),
                new CreateTelevisionCategoryMappingBindingModel(foxHdId, actionCategoryId),
                new CreateTelevisionCategoryMappingBindingModel(hbo2HdId, documentaryCategoryId),
                new CreateTelevisionCategoryMappingBindingModel(hbo2HdId, actionCategoryId),
            };

            this.ListOfDTOEntities = televisionCategoryMappingList;
        }
    }
}
