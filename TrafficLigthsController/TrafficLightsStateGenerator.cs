using System;
using POCOLib;

namespace TrafficLigthControllers {
	class TrafficLightsStateGenerator : ITrafficLightsStateProvider {
		public TrafficLightsStateGenerator() => this.random = new Random();

		public TrafficLightState.Light GetCurrentState() => genearteState();

		private TrafficLightState.Light genearteState() => ( TrafficLightState.Light ) random.Next(0, Enum.GetNames(typeof(TrafficLightState.Light)).Length);

		private Random random;
	}
}
