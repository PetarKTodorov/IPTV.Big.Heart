namespace IPTV.Big.Heart.Services.Database.User
{
    using System.Linq;

    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.User;

    public class RoleService : BaseDatabaseService<Role>, IRoleService
    {
        public RoleService(IRepository<Role> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {

        }

        public Role GetRoleByName(string name)
        {
            var roles = this.GetAllAsync<Role>().GetAwaiter().GetResult();

            var role = roles.SingleOrDefault(r => r.Name == name);

            return role;
        }
    }
}
