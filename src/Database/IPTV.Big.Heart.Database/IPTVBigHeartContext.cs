namespace IPTV.Big.Heart.Database
{
    using Microsoft.EntityFrameworkCore;

    using Common.Database;

    using Models.User;
    using Models.Location;
    using Models.Television;

    public class IPTVBigHeartContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRoleMapping> UserRoleMapping  { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Television> Televisions { get; set; }

        public DbSet<TelevisionCategory> TelevisionCategories { get; set; }

        public DbSet<TelevisionCategoryMapping> TelevisionCategoryMapping { get; set; }

        public DbSet<TelevisionCountryMapping> TelevisionCountryMapping { get; set; }

        public DbSet<Stream> Streams { get; set; }

        public DbSet<TelevisionStreamMapping> TelevisionStreamMapping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Constants.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
