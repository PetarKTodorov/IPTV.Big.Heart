namespace IPTV.Big.Heart.Services.Database.Location
{
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.Location;
    using System.Threading.Tasks;
    using System.Linq;

    public class CountryService : BaseDatabaseService<Country>, ICountryService
    {
        public CountryService(IRepository<Country> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {
        }

        public async Task<Country> GetByName(string countryName)
        {
            var country = this.Repositary.GetAll().SingleOrDefault(country => country.Name == countryName);

            return country;
        }
    }
}
