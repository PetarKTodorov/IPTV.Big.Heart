namespace IPTV.Big.Heart.Database.EntityTypeConfigurations.User
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.User;

    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.Country)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CountryId);

            builder.HasIndex(u => u.Email)
                .IsUnique()
                .IsClustered(false);

            builder.Property(u => u.Email)
                .IsRequired();
        }
    }
}
