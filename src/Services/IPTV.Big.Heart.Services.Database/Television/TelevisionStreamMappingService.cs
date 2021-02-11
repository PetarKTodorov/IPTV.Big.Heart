namespace IPTV.Big.Heart.Services.Database.Television
{
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.Television;

    public class TelevisionStreamMappingService : BaseDatabaseService<TelevisionStreamMapping>, ITelevisionStreamMappingService
    {
        public TelevisionStreamMappingService(IRepository<TelevisionStreamMapping> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {

        }
    }
}
