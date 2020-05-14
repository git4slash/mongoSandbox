using DataSourceLib.Interfaces;
using DataSourceLib.MongoDbImpl;
using POCOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLigthControllers
{
    public class TrafficLightDeviceStatusController {
        private readonly IAsyncRepository<TrafficLightDevice> deviceStatusRepo;

        public TrafficLightDeviceStatusController(TrafficLightDevice device) {
            this.deviceStatusRepo = new MongoDbRepoService().GetRepository(device);
        }

        public IQueryable<TrafficLightState> GetTrafficLightStates(TrafficLightDevice device) {
            throw new NotImplementedException();
            this.deviceStatusRepo.AsQueryable();
        }
    }
}
