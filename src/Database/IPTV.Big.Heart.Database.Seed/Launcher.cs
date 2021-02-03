namespace IPTV.Big.Heart.Database.Seed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    using IPTV.Big.Heart.Database.Seed.Seeders.Interfaces;
    using IPTV.Big.Heart.Database.Seed.Seeders.Location;
    using IPTV.Big.Heart.Database.Seed.Seeders.User;

    public static class Launcher
    {
        public static async Task<bool> SeedDatabaseAsync(this IApplicationBuilder app)
        {
            bool isDatabaseAlreadySeeded;

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                IEnumerable<ISeeder> seeders = InitializeSeeders(serviceScope.ServiceProvider);

                isDatabaseAlreadySeeded = await RunSeeders(seeders);
            }

            return isDatabaseAlreadySeeded;
        }

        private static IEnumerable<ISeeder> InitializeSeeders(IServiceProvider serviceProvider)
        {
            var seeders = new List<ISeeder>
            {
                new CountrySeeder(serviceProvider),
                new UserSeeder(serviceProvider),
                new RoleSeeder(serviceProvider),
            };

            return seeders;
        }

        private static async Task<bool> RunSeeders(IEnumerable<ISeeder> seeders)
        {
            bool isInDatabaseAlreadyAllEntitiesSeeded = 
                seeders.ToList().TrueForAll(s => s.IsAlreadyExistEntitiesAsync().GetAwaiter().GetResult() == true);

            if (isInDatabaseAlreadyAllEntitiesSeeded)
            {
                return false;
            }
       
            foreach (ISeeder seeder in seeders)
            {
                if (await seeder.IsAlreadyExistEntitiesAsync() == true)
                {
                    continue;
                }

                seeder.GenerateList();
                await seeder.SeedAsync();
            }

            return isInDatabaseAlreadyAllEntitiesSeeded;
        }
    }
}
