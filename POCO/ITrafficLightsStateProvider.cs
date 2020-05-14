namespace POCOLib {
	public interface ITrafficLightsStateProvider {
		TrafficLightState.Light GetCurrentState();
	}
}