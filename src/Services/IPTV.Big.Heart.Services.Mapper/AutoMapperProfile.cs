namespace IPTV.Big.Heart.Services.Mapper
{
    using AutoMapper;

    using Database.Models.Location;
    using DTOs.BindingModels.Location;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<CreateCountryBindingModel, Country>();
        }
    }
}
