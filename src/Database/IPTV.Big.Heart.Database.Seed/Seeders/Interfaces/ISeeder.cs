namespace IPTV.Big.Heart.Database.Seed.Seeders.Interfaces
{
    using System.Threading.Tasks;

    internal interface ISeeder
    {
        public Task SeedAsync();

        public Task<bool> IsAlreadyExistEntitiesAsync();

        public abstract void GenerateList();
    }
}
