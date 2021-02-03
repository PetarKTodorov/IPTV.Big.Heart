namespace IPTV.Big.Heart.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;

    public abstract class BaseDatabaseService<TEntity> : IBaseDatabaseService<TEntity>
    {
        private readonly IRepositary<TEntity> repositary;
        private readonly IMapper mapper;

        public BaseDatabaseService(IRepositary<TEntity> repositary, IMapper mapper)
        {
            this.repositary = repositary;
            this.mapper = mapper;
        }

        public async Task<TEntity> CreateAsync<DTO>(DTO entity)
        {
            TEntity newEntity = this.mapper.Map<TEntity>(entity);

            newEntity = await this.repositary.CreateAsync(newEntity);

            return newEntity;
        }

        public async Task<TEntity> DeleteAsync<T>(T id)
        {
            TEntity entity = await this.GetByIdAsync(id);

            entity = await this.repositary.DeleteAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IEnumerable<TEntity> collection = await this.repositary.GetAllAsync();

            return collection;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool isDeletedFlag)
        {
            IEnumerable<TEntity> collection = await this.repositary.GetAllAsync(isDeletedFlag);

            return collection;
        }

        public async Task<TEntity> GetByIdAsync<T>(T id)
        {
            TEntity entity = await this.repositary.GetByIdAsync(id);

            if (entity == null)
            {
                throw new Exception("There is no such entity.");
            }

            return entity;
        }

        public async Task<TEntity> GetByIdAsync<T>(T id, bool isDeletedFlag)
        {
            TEntity entity = await this.GetByIdAsync(id, isDeletedFlag);

            if (entity == null)
            {
                throw new Exception("There is no such entity.");
            }

            return entity;
        }

        public async Task<TEntity> UnDeleteAsync<T>(T id)
        {
            TEntity entity = await this.GetByIdAsync(id);

            entity = await this.repositary.UnDeleteAsync(entity);

            return entity;
        }

        public async Task<TEntity> UpdateAsync<T, DTO>(T id, DTO entity)
        {
            TEntity dbEntity = await this.GetByIdAsync(id);

            dbEntity = this.mapper.Map<TEntity>(entity);

            dbEntity = await this.repositary.UpdateAsync(dbEntity);

            return dbEntity;
        }

    }
}
