namespace IPTV.Big.Heart.Services.Database.Television
{
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.Television;

    public class TelevisionService : BaseDatabaseService<Television>, ITelevisionService
    {
        public TelevisionService(IRepositary<Television> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {

        }
    }
}
