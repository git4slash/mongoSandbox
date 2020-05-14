using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataSourceLib.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using POCOLib;

namespace DataSourceLib.MongoDbImpl {
	public class TrafficLightDevicesRepository : AbstractAsyncMongoRepository<TrafficLightDevice> {
		public TrafficLightDevicesRepository(IDataSourceSettings dsSettings) : base(dsSettings) { }

		#region AbstractAsyncMongoRepository impl
		public override IQueryable<TrafficLightDevice> AsQueryable(Expression<Func<TrafficLightDevice, bool>> filter) =>
			 base.DB.ListCollectionNames(new ListCollectionNamesOptions())
					.ToEnumerable()
					.Select(this.colNameToDevice)
					.AsQueryable();

		public override Task CreateAsync(TrafficLightDevice dev) {
			var colName = getTrafficLightDeviceCollectionName(dev);
			return base.DB.CreateCollectionAsync(colName)
							.ContinueWith(_ => DB.GetCollection<BsonDocument>(colName)
													.InsertOne(dev.ToBsonDocument()));
		}

		public override Task CreateManyAsync(IEnumerable<TrafficLightDevice> devices) =>
			Task.WhenAll(devices.Select(this.CreateAsync));

		public override Task DeleteAsync(Guid objId) => base.DB.DropCollectionAsync(getTrafficLightDeviceCollectionName(objId));

		public override Task DeleteAsync(TrafficLightDevice obj) => base.DB.DropCollectionAsync(getTrafficLightDeviceCollectionName(obj));

		public override Task<TrafficLightDevice> FindByIdAsync(Guid objId) =>
			Task.FromResult(this.colNameToDevice(getTrafficLightDeviceCollectionName(objId)));

		public override Task UpdateAsync(Guid objId, TrafficLightDevice newObj) =>
			this.DeleteAsync(objId).ContinueWith(_ => this.CreateAsync(newObj));
		#endregion

		private TrafficLightDevice colNameToDevice(string colName) {
			var id = EntityToCollectionNameResolver.GetCollectionNameSuffix(colName, EntityToCollectionNameResolver.CollectionNamePrefixes.TrafficLightDevice);
			return base.DB.GetCollection<TrafficLightDevice>(colName)
							.AsQueryable()
							.First();
		}

		private static string getTrafficLightDeviceCollectionName(TrafficLightDevice dev) =>
			getTrafficLightDeviceCollectionName(dev.Id);

		private static string getTrafficLightDeviceCollectionName(Guid devId) =>
			EntityToCollectionNameResolver.GetCollectionName<TrafficLightDevice>(devId);
	}
}
