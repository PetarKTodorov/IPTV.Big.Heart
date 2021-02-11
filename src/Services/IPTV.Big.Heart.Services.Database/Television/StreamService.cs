namespace IPTV.Big.Heart.Services.Database.Television
{
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.Television;

    public class StreamService : BaseDatabaseService<Stream>, IStreamService
    {
        public StreamService(IRepository<Stream> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {

        }
    }
}
