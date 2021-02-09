namespace IPTV.Big.Heart.Database.Seed.Seeders.Television
{
    using System;
    using System.Collections.Generic;

    using IPTV.Big.Heart.Database.Models.Television;
    using IPTV.Big.Heart.DTOs.BindingModels.Television.Create;
    using IPTV.Big.Heart.Services.Database.Television.Interfaces;

    public class TelevisionCategorySeeder : BaseSeeder<ITelevisionCategoryService, TelevisionCategory, CreateTelevisionCategoryBindingModel>
    {
        public TelevisionCategorySeeder(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }

        public override void GenerateList()
        {
            this.ListOfDTOEntities = new List<CreateTelevisionCategoryBindingModel>
            {
                new CreateTelevisionCategoryBindingModel(Constants.TelevisionCategory1),
                new CreateTelevisionCategoryBindingModel(Constants.TelevisionCategory2),
                new CreateTelevisionCategoryBindingModel(Constants.TelevisionCategory3),
            };
        }
    }
}
