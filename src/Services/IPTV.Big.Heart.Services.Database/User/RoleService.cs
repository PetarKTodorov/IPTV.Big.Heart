namespace IPTV.Big.Heart.Services.Database.User
{
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.User;

    public class RoleService : BaseDatabaseService<Role>, IRoleService
    {
        public RoleService(IRepositary<Role> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {

        }
    }
}
