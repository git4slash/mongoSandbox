using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataSourceLib.Interfaces;
using MongoDB.Driver;
using POCOLib;

namespace DataSourceLib.MongoDbImpl {

	public class CollectionBasedGenericMongoDbRepository<TEntity> : AbstractAsyncMongoRepository<TEntity> where TEntity : BaseEntity {

		public CollectionBasedGenericMongoDbRepository(IDataSourceSettings dsSettings, string colName) : base(dsSettings) =>
			this.Collection = DB.GetCollection<TEntity>(colName);

		protected IMongoCollection<TEntity> Collection { get; set; }

		#region AbstractAsyncMongoRepository impl
		public override Task CreateAsync(TEntity obj) => Collection.InsertOneAsync(obj);
		public override Task CreateManyAsync(IEnumerable<TEntity> entities) =>
			Collection.InsertManyAsync(entities);

		public override Task DeleteAsync(Guid objId) =>
			Collection.DeleteOneAsync(_o => _o.Id == objId);
		public override Task DeleteAsync(TEntity obj) => this.DeleteAsync(obj.Id);

		public override IQueryable<TEntity> AsQueryable(Expression<Func<TEntity, bool>> filter) =>
			Collection.AsQueryable();

		public override Task<TEntity> FindByIdAsync(Guid objId) =>
			Collection.Find(_o => _o.Id == objId).FirstOrDefaultAsync();

		public override Task UpdateAsync(Guid objId, TEntity newObj) =>
			Collection.ReplaceOneAsync(_o => _o.Id == objId, newObj);
		#endregion
	}
}
