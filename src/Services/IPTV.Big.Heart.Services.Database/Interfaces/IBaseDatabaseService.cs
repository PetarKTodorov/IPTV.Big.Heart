namespace IPTV.Big.Heart.Services.Database.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBaseDatabaseService<TEntity>
    {
        public Task<TEntity> CreateAsync<DTO>(DTO entity);

        public Task<IEnumerable<DTO>> GetAllAsync<DTO>();

        public Task<IEnumerable<DTO>> GetAllAsync<DTO>(bool isDeletedFlag);

        public Task<TEntity> GetByIdAsync<T>(T id);

        public Task<TEntity> GetByIdAsync<T>(T id, bool isDeletedFlag);

        public Task<TEntity> UpdateAsync<T, DTO>(T id, DTO entity);

        public Task<TEntity> DeleteAsync<T>(T id);

        public Task<TEntity> UnDeleteAsync<T>(T id);
    }
}
