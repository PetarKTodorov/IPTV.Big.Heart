namespace IPTV.Big.Heart.Application.Infrastructures
{
    using System.Threading.Tasks;
    using IPTV.Big.Heart.Database;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DatabaseMigrationExtention
    {
        public static async Task MigrateDatabaseAsync(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<IPTVBigHeartContext>();

                //await dbContext.Database.EnsureCreatedAsync();

                await dbContext.Database.MigrateAsync();
            }
        }
    }
}
