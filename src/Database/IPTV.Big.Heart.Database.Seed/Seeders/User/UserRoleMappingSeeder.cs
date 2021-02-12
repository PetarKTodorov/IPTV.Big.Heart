namespace IPTV.Big.Heart.Database.Seed.Seeders.User
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;

    using IPTV.Big.Heart.Database.Models.User;
    using IPTV.Big.Heart.DTOs.BindingModels.User.Create;
    using IPTV.Big.Heart.Services.Database.User.Interfaces;
    using IPTV.Big.Heart.Common;

    public class UserRoleMappingSeeder : BaseSeeder<IUserRoleMappingService, UserRoleMapping, CreateUserRoleMappingBindingModel>
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public UserRoleMappingSeeder(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
            this.userService = serviceProvider.GetRequiredService<IUserService>();
            this.roleService = serviceProvider.GetRequiredService<IRoleService>();
        }

        public override void GenerateList()
        {
            var adminUser = userService.GetUserByEmail(Constants.AdminEmail);
            var adminRole = roleService.GetRoleByName(GlobalConstants.AdminRole);

            var normalUser = userService.GetUserByEmail(Constants.UserEmail);
            var normalRole = roleService.GetRoleByName(GlobalConstants.UserRole);

            this.ListOfDTOEntities = new List<CreateUserRoleMappingBindingModel>
            {
                new CreateUserRoleMappingBindingModel(adminUser.Id, adminRole.Id),
                new CreateUserRoleMappingBindingModel(normalUser.Id, normalRole.Id),
            };
        }
    }
}
