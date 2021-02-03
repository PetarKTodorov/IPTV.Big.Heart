namespace IPTV.Big.Heart.Database.EntityTypeConfigurations.Television
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.Television;

    internal class TelevisionStreamMappingConfiguration : IEntityTypeConfiguration<TelevisionStreamMapping>
    {
        public void Configure(EntityTypeBuilder<TelevisionStreamMapping> builder)
        {
            builder.HasAlternateKey(tsm => new { tsm.TelevisionId, tsm.StreamId });

            builder.HasOne(tsm => tsm.Television)
                .WithMany(t => t.Streams)
                .HasForeignKey(tsm => tsm.TelevisionId);

            builder.HasOne(tsm => tsm.Stream)
                .WithMany(s => s.Televisions)
                .HasForeignKey(tsm => tsm.StreamId);
        }
    }
}
