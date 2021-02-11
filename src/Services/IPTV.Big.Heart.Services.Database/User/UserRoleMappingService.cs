namespace IPTV.Big.Heart.Services.Database.User
{
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.User;

    public class UserRoleMappingService : BaseDatabaseService<UserRoleMapping>, IUserRoleMappingService
    {
        public UserRoleMappingService(IRepository<UserRoleMapping> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {

        }
    }
}
