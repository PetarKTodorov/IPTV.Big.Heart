namespace IPTV.Big.Heart.Services.Database.Location
{
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.Location;

    public class CountryService : BaseDatabaseService<Country>, ICountryService
    {
        public CountryService(IRepositary<Country> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {
        }
    }
}
