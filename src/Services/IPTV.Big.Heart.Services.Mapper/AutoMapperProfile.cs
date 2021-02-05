namespace IPTV.Big.Heart.Services.Mapper
{
    using AutoMapper;

    using Database.Models.Location;
    using DTOs.BindingModels.Location;
    using IPTV.Big.Heart.Database.Models.Television;
    using IPTV.Big.Heart.Database.Models.User;
    using IPTV.Big.Heart.DTOs.BindingModels.Television;
    using IPTV.Big.Heart.DTOs.BindingModels.User;

    // @TODO Make it with reflection, think about make interface end binding models implement it
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<CreateCountryBindingModel, Country>();

            this.CreateMap<CreateUserBindingModel, User>();

            this.CreateMap<CreateRoleBindingModel, Role>();

            this.CreateMap<CreateUserRoleMappingBindingModel, UserRoleMapping>();

            this.CreateMap<CreateStreamBindingModel, Stream>();

            this.CreateMap<CreateTelevisionBindingModel, Television>();

            this.CreateMap<CreateTelevisionCategoryBindingModel, TelevisionCategory>();

            this.CreateMap<CreateTelevisionCategoryMappingBindingModel, TelevisionCategoryMapping>();

            this.CreateMap<CreateTelevisionCountryMappingBindingModel, TelevisionCountryMapping>();

            this.CreateMap<CreateTelevisionStreamMappingBindingModel, TelevisionStreamMapping>();
        }
    }
}
