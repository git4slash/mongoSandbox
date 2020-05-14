using DataSourceLib.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using POCOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataSourceLib.MongoDbImpl
{
    public abstract class AbstractAsyncMongoRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        protected AbstractAsyncMongoRepository(IDataSourceSettings settings) {
            registerClassMappers();
            this.DB = getDb(settings);
        }

        protected IMongoDatabase DB { get; set; }

        protected static IMongoDatabase getDb(IDataSourceSettings settings) =>
            new MongoClient(settings.ResourceUri).GetDatabase(settings.ResourceName);

        protected static void registerClassMappers()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(BaseEntity))) {
                BsonClassMap.RegisterClassMap<BaseEntity>(classMapInitializer => {
                    classMapInitializer.AutoMap();
                    classMapInitializer.SetIdMember(classMapInitializer.GetMemberMap(be => be.Id));
                    classMapInitializer.IdMemberMap.SetIdGenerator(CombGuidGenerator.Instance);
                });
            }
        }

        #region IAsyncRepository abstract members
        public abstract IQueryable<TEntity> AsQueryable(Expression<Func<TEntity, bool>> filter);
        public abstract Task CreateAsync(TEntity obj);
        public abstract Task CreateManyAsync(IEnumerable<TEntity> entities);
        public abstract Task DeleteAsync(Guid objId);
        public abstract Task DeleteAsync(TEntity obj);
        public abstract Task<TEntity> FindByIdAsync(Guid objId);
        public abstract Task UpdateAsync(Guid objId, TEntity newObj);
        #endregion
    }
}
