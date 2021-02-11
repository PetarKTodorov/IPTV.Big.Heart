namespace IPTV.Big.Heart.Database.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Models.Interfaces;

    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBaseModel
    {
        private readonly IPTVBigHeartContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public BaseRepository(IPTVBigHeartContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;

            var newEntity = await this.dbSet.AddAsync(entity);

            await this.SaveChangesAsync();

            return newEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.LastModifiedAt = DateTime.UtcNow;

            var updatedEntity = this.dbSet.Update(entity);

            await this.SaveChangesAsync();

            return updatedEntity.Entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.UtcNow;

            var deletedEntity = await this.UpdateAsync(entity);

            return deletedEntity;
        }

        public async Task<TEntity> UnDeleteAsync(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedAt = null;

            var unDeletedEntity = await this.UpdateAsync(entity);

            return unDeletedEntity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var collection = await this.GetAll().ToArrayAsync();

            return collection;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool isDeletedFlag)
        {
            var collection = await this.GetAll()
                .Where(entity => entity.IsDeleted == isDeletedFlag)
                .ToArrayAsync();

            return collection;
        }

        public async Task<TEntity> GetByIdAsync<T>(T id)
        {
            var entity = await this.dbSet.FindAsync(id);

            return entity;
        }

        public async Task<TEntity> GetByIdAsync<T>(T id, bool isDeletedFlag)
        {
            var entity = await this.dbSet.FindAsync(id);

            if (entity?.IsDeleted != isDeletedFlag)
            {
                return null;
            }

            return entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            int countOfRowsAffected = await this.dbContext.SaveChangesAsync();

            return countOfRowsAffected;
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.dbSet.AsQueryable();
        }
    }
}
