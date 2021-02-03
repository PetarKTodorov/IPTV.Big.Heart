namespace IPTV.Big.Heart.DTOs.BindingModels.User
{
    using System;

    public class CreateUserRoleMappingBindingModel
    {
        public CreateUserRoleMappingBindingModel(Guid userId, Guid roleId)
        {
            this.UserId = userId;
            this.RoleId = roleId;
        }

        public Guid RoleId { get; set; }

        public Guid UserId { get; set; }
    }
}
