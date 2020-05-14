using POCOLib;

namespace DataSourceLib.Interfaces {
	public interface IAsyncRepositoryProvider {
		IAsyncRepository<TEntity> GetRepository<TEntity>() where TEntity : TrafficLightDevice;
		IAsyncRepository<TEntity> GetRepository<TEntity>(TEntity entity) where TEntity : BaseEntity;

	}
}
