using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataSourceLib.Interfaces;
using DataSourceLib.MongoDbImpl;
using POCOLib;

namespace TrafficLigthControllers {
	public class TrafficLightDevicesController {
		public TrafficLightDevicesController() =>
			this.trafficLightRepo = new MongoDbRepoService().GetRepository<TrafficLightDevice>();

        #region Device CRUD impl
        public async void Save(TrafficLightDevice device) =>
            await this.trafficLightRepo.CreateAsync(device);

		public async void SaveMany(IEnumerable<TrafficLightDevice> entities) =>
			await this.trafficLightRepo.CreateManyAsync(entities);

		public TrafficLightDevice FindOneById(Guid objId) =>
			this.trafficLightRepo.FindByIdAsync(objId).Result;

		public IQueryable<TrafficLightDevice> GetAllDevices(Expression<Func<TrafficLightDevice, bool>> expression) =>
			this.trafficLightRepo.AsQueryable(expression);

		public async void UpdateDevice(Guid devId, TrafficLightDevice newDeviceStatus) =>
			await this.trafficLightRepo.UpdateAsync(devId, newDeviceStatus);

        public async void Delete(TrafficLightDevice device) =>
            await this.trafficLightRepo.DeleteAsync(device);

        public async void Delete(Guid id) =>
            await this.trafficLightRepo.DeleteAsync(id);
		#endregion

		#region Variables and Properties
		private IAsyncRepository<TrafficLightDevice> trafficLightRepo;
		#endregion
	}
}
