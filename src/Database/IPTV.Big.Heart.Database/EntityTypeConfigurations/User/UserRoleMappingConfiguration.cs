namespace IPTV.Big.Heart.Database.EntityTypeConfigurations.Television
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.User;

    internal class UserRoleMappingConfiguration : IEntityTypeConfiguration<UserRoleMapping>
    {
        public void Configure(EntityTypeBuilder<UserRoleMapping> builder)
        {
            builder.HasAlternateKey(urm => new { urm.UserId, urm.RoleId });

            builder.HasOne(urm => urm.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(urm => urm.UserId);

            builder.HasOne(urm => urm.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(urm => urm.RoleId);
        }
    }
}
