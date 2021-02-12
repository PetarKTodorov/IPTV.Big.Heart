namespace IPTV.Big.Heart.Database.Seed.Seeders.User
{
    using System;
    using System.Collections.Generic;
    using IPTV.Big.Heart.Common;
    using IPTV.Big.Heart.Database.Models.User;
    using IPTV.Big.Heart.DTOs.BindingModels.User.Create;
    using IPTV.Big.Heart.Services.Database.User.Interfaces;

    public class RoleSeeder : BaseSeeder<IRoleService, Role, CreateRoleBindingModel>
    {
        public RoleSeeder(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        public override void GenerateList()
        {
            this.ListOfDTOEntities = new List<CreateRoleBindingModel>
            {
                new CreateRoleBindingModel(GlobalConstants.AdminRole),
                new CreateRoleBindingModel(GlobalConstants.UserRole),
            };
        }
    }
}
