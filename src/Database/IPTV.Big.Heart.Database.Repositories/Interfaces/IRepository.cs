﻿namespace IPTV.Big.Heart.Database.Repositories.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<TEntity>
    {
        public Task<TEntity> CreateAsync(TEntity entity);

        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task<IEnumerable<TEntity>> GetAllAsync(bool isDeletedFlag);

        public Task<TEntity> GetByIdAsync<T>(T id);

        public Task<TEntity> GetByIdAsync<T>(T id, bool isDeletedFlag);

        public Task<TEntity> UpdateAsync(TEntity entity);

        public Task<TEntity> DeleteAsync(TEntity entity);

        public Task<TEntity> UnDeleteAsync(TEntity entity);

        public Task<int> SaveChangesAsync();

        IQueryable<TEntity> GetAll();
    }
}
