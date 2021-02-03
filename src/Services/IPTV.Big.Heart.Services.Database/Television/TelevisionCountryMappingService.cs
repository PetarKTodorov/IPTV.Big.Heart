namespace IPTV.Big.Heart.Services.Database.Television
{
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.Television;

    public class TelevisionCountryMappingService : BaseDatabaseService<TelevisionCountryMapping>, ITelevisionCountryMappingService
    {
        public TelevisionCountryMappingService(IRepositary<TelevisionCountryMapping> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {

        }
    }
}
