namespace IPTV.Big.Heart.Services.Database.Television
{
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.Television;

    public class TelevisionCategoryService : BaseDatabaseService<TelevisionCategory>, ITelevisionCategoryService
    {
        public TelevisionCategoryService(IRepository<TelevisionCategory> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {

        }
    }
}
