namespace IPTV.Big.Heart.Database.EntityTypeConfigurations.Television
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.Television;

    internal class TelevisionCountryMappingConfiguration : IEntityTypeConfiguration<TelevisionCountryMapping>
    {
        public void Configure(EntityTypeBuilder<TelevisionCountryMapping> builder)
        {
            builder.HasKey(tcm => new { tcm.TelevisionId, tcm.CountryId });

            builder.HasOne(tcm => tcm.Television)
                .WithMany(t => t.Countries)
                .HasForeignKey(tcm => tcm.TelevisionId);

            builder.HasOne(tcm => tcm.Country)
                .WithMany(c => c.Televisions)
                .HasForeignKey(tcm => tcm.CountryId);
        }
    }
}
