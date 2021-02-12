namespace IPTV.Big.Heart.Services.Mapper
{
    using System.Linq;
    using AutoMapper;

    using Database.Models.Location;
    using DTOs.BindingModels.Location.Create;
    using IPTV.Big.Heart.Database.Models.Television;
    using IPTV.Big.Heart.Database.Models.User;
    using IPTV.Big.Heart.DTOs.BindingModels.Location.Edit;
    using IPTV.Big.Heart.DTOs.BindingModels.Television.Create;
    using IPTV.Big.Heart.DTOs.BindingModels.Television.Edit;
    using IPTV.Big.Heart.DTOs.BindingModels.User;
    using IPTV.Big.Heart.DTOs.BindingModels.User.Create;
    using IPTV.Big.Heart.DTOs.ViewModels.Location;
    using IPTV.Big.Heart.DTOs.ViewModels.Television;

    // @TODO Make it with reflection, think about make interface end binding models implement it
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<CreateCountryBindingModel, Country>().ReverseMap();

            this.CreateMap<CreateUserBindingModel, User>().ReverseMap();

            this.CreateMap<CreateRoleBindingModel, Role>().ReverseMap();

            this.CreateMap<CreateUserRoleMappingBindingModel, UserRoleMapping>().ReverseMap();

            this.CreateMap<CreateStreamBindingModel, Stream>().ReverseMap();

            this.CreateMap<CreateTelevisionBindingModel, Television>().ReverseMap();

            this.CreateMap<CreateTelevisionCategoryBindingModel, TelevisionCategory>().ReverseMap();

            this.CreateMap<CreateTelevisionCategoryMappingBindingModel, TelevisionCategoryMapping>().ReverseMap();

            this.CreateMap<CreateTelevisionCountryMappingBindingModel, TelevisionCountryMapping>().ReverseMap();

            this.CreateMap<CreateTelevisionStreamMappingBindingModel, TelevisionStreamMapping>().ReverseMap();

            this.CreateMap<LoginBindingModel, User>()
                .ForMember(u => u.PasswordHash, options => options.MapFrom(lbm => lbm.Password))
                .ReverseMap();

            this.CreateMap<RegisterBindingModel, CreateUserBindingModel>().ReverseMap();

            
            this.CreateMap<EditCountryBindingModel, Country>();
            this.CreateMap<EditTelevisionBindingModel, Television>();

            this.CreateMap<Country, CountryViewModel>().ReverseMap();
            this.CreateMap<Stream, StreamViewModel>().ReverseMap();
            this.CreateMap<TelevisionCategory, TelevisionCategoryViewModel>().ReverseMap();

            //GetAllTelevisionViewModel
            this.CreateMap<Television, GetAllTelevisionViewModel>()
                .ForMember(vm => vm.Categoties, options => options.MapFrom(t => t.Categories.Select(x => x.Category)))
                .ForMember(vm => vm.Countries, options => options.MapFrom(t => t.Countries.Select(x => x.Country)))
                .ForMember(vm => vm.Streams, options => options.MapFrom(t => t.Streams.Select(x => x.Stream)))
                .ReverseMap();
        }
    }
}
