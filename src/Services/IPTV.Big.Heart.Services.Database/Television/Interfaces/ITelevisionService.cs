namespace IPTV.Big.Heart.Services.Database.Television.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IPTV.Big.Heart.Database.Models.Television;
    using IPTV.Big.Heart.Services.Database.Interfaces;

    public interface ITelevisionService : IBaseDatabaseService<Television>
    {
        IEnumerable<DTO> GetAllInformation<DTO>();

        Task<Television> GetByName(string name);
    }
}
