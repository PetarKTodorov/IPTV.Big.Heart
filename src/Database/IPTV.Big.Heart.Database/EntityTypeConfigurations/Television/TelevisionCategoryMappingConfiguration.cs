namespace IPTV.Big.Heart.Database.EntityTypeConfigurations.Television
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.Television;

    internal class TelevisionCategoryMappingConfiguration : IEntityTypeConfiguration<TelevisionCategoryMapping>
    {
        public void Configure(EntityTypeBuilder<TelevisionCategoryMapping> builder)
        {
            builder.HasKey(tcm => new { tcm.TelevisionId, tcm.CategoryId });

            builder.HasOne(tcm => tcm.Television)
                .WithMany(t => t.Categories)
                .HasForeignKey(tcm => tcm.TelevisionId);

            builder.HasOne(tcm => tcm.Category)
                .WithMany(tc => tc.Televisions)
                .HasForeignKey(tcm => tcm.CategoryId);
        }
    }
}
