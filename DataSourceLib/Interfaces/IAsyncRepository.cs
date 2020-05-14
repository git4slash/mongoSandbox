using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using POCOLib;

namespace DataSourceLib.Interfaces {
	public interface IAsyncRepository<TEntity> where TEntity : BaseEntity {

		Task CreateAsync(TEntity obj);

		Task CreateManyAsync(IEnumerable<TEntity> entities);

		Task<TEntity> FindByIdAsync(Guid objId);

		IQueryable<TEntity> AsQueryable(Expression<Func<TEntity, bool>> filter = null);

		Task UpdateAsync(Guid objId, TEntity newObj);

		Task DeleteAsync(Guid objId);

		Task DeleteAsync(TEntity obj);

	}
}
