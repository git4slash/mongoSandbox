using DataSourceLib.Interfaces;
using POCOLib;

namespace DataSourceLib.MongoDbImpl {
	public class MongoDbRepoService : IAsyncRepositoryProvider {

		private static readonly IDataSourceSettings dsSettings = new MongoDbDataSourceSettings();

		public IAsyncRepository<TEntity> GetRepository<TEntity>() where TEntity : TrafficLightDevice =>
			new TrafficLightDevicesRepository(dsSettings) as IAsyncRepository<TEntity>;

		public IAsyncRepository<TEntity> GetRepository<TEntity>(TEntity entity) where TEntity : BaseEntity => new CollectionBasedGenericMongoDbRepository<TEntity>(dsSettings,
													EntityToCollectionNameResolver.GetCollectionName(entity));
	}
}
