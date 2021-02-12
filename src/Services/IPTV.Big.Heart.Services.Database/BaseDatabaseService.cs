namespace IPTV.Big.Heart.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;

    public abstract class BaseDatabaseService<TEntity> : IBaseDatabaseService<TEntity>
    {
        public BaseDatabaseService(IRepository<TEntity> repositary, IMapper mapper)
        {
            this.Repositary = repositary;
            this.Mapper = mapper;
        }

        protected IRepository<TEntity> Repositary { get; private set; }

        protected IMapper Mapper { get; private set; }

        public async Task<TEntity> CreateAsync<DTO>(DTO entity)
        {
            TEntity newEntity = this.Mapper.Map<TEntity>(entity);

            newEntity = await this.Repositary.CreateAsync(newEntity);

            return newEntity;
        }

        public async Task<TEntity> DeleteAsync<T>(T id)
        {
            TEntity entity = await this.GetByIdAsync(id);

            entity = await this.Repositary.DeleteAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<DTO>> GetAllAsync<DTO>()
        {
            var collectionFromDb = await this.Repositary.GetAllAsync();

            IEnumerable<DTO> collection = this.Mapper.Map<IEnumerable<DTO>>(collectionFromDb);

            return collection;
        }

        public async Task<IEnumerable<DTO>> GetAllAsync<DTO>(bool isDeletedFlag)
        {
            var collectionFromDb = await this.Repositary.GetAllAsync(isDeletedFlag);

            IEnumerable<DTO> collection = this.Mapper.Map<IEnumerable<DTO>>(collectionFromDb);

            return collection;
        }

        public async Task<TEntity> GetByIdAsync<T>(T id)
        {
            TEntity entity = await this.Repositary.GetByIdAsync(id);

            return entity;
        }

        public async Task<TEntity> GetByIdAsync<T>(T id, bool isDeletedFlag)
        {
            TEntity entity = await this.Repositary.GetByIdAsync(id, isDeletedFlag);

            return entity;
        }

        public async Task<TEntity> UnDeleteAsync<T>(T id)
        {
            TEntity entity = await this.GetByIdAsync(id);

            entity = await this.Repositary.UnDeleteAsync(entity);

            return entity;
        }

        public async Task<TEntity> UpdateAsync<T, DTO>(T id, DTO entity)
        {
            TEntity dbEntity = await this.GetByIdAsync(id);

            dbEntity = this.Mapper.Map(entity, dbEntity);

            dbEntity = await this.Repositary.UpdateAsync(dbEntity);

            return dbEntity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.Repositary.GetAll();
        }

    }
}
