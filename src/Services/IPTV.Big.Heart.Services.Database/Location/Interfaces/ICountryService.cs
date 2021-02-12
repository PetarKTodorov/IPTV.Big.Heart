namespace IPTV.Big.Heart.Services.Database.Location.Interfaces
{
    using System.Threading.Tasks;
    using IPTV.Big.Heart.Database.Models.Location;
    using IPTV.Big.Heart.Services.Database.Interfaces;

    public interface ICountryService : IBaseDatabaseService<Country>
    {
        Task<Country> GetByName(string name);
    }
}
