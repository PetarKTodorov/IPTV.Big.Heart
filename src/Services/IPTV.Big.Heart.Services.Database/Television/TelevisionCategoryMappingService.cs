namespace IPTV.Big.Heart.Services.Database.Television
{
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.Television;

    public class TelevisionCategoryMappingService : BaseDatabaseService<TelevisionCategoryMapping>, ITelevisionCategoryMappingService
    {
        public TelevisionCategoryMappingService(IRepository<TelevisionCategoryMapping> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {

        }
    }
}
