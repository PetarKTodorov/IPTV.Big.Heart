namespace IPTV.Big.Heart.Database.Seed.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    using Microsoft.Extensions.DependencyInjection;

    using IPTV.Big.Heart.Services.Database.Interfaces;
    using Interfaces;

    public abstract class BaseSeeder<TService, TEntity, DTO> : ISeeder
        where TService : IBaseDatabaseService<TEntity>
        where DTO : class
    {
        public BaseSeeder(IServiceProvider serviceProvider)
        {
            this.Service = serviceProvider.GetRequiredService<TService>();
        }

        protected TService Service { get; set; }

        protected IEnumerable<DTO> ListOfDTOEntities { get; set; }

        public async Task<bool> IsAlreadyExistEntitiesAsync()
        {
            var entities = await this.Service.GetAllAsync<DTO>();

            bool isAlreadyExistEntities = entities.Any();

            return isAlreadyExistEntities;
        }

        public async Task SeedAsync()
        {
            foreach (var entity in this.ListOfDTOEntities)
            {
                await this.Service.CreateAsync(entity);
            }
        }

        public abstract void GenerateList();
    }
}
