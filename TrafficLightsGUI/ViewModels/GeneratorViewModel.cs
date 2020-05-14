using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using POCOLib;
using TrafficLigthControllers;

namespace TrafficLightsGUI.ViewModels {
	[POCOViewModel]
	public class GeneratorViewModel {
		private readonly TrafficLightDevicesController _devicesController;
		private static readonly Random _random = new Random();

		protected GeneratorViewModel() {
			this._devicesController = new TrafficLightDevicesController();
		}

		public static GeneratorViewModel Create() =>
			ViewModelSource.Create(() => new GeneratorViewModel());

		public void GenerateDevice() => this._devicesController.Save(GetGeneratedDevice());
		public bool CanGenerateDevice() => true;

		public void GenarateState(TrafficLightDevice device) {
			//Enumerable.Range(0, 1000)
			//.Select(generateState);
		}

		private static TrafficLightState generateState() =>
			new TrafficLightState(DateTime.Now, TrafficLightState.Light.Green);
		public static TrafficLightDevice GetGeneratedDevice() =>
			new TrafficLightDevice {
				Id = Guid.NewGuid(),
				Name = $"Device# { _random.Next(0, 1000) }"
			};

		public bool CanGenerateState(TrafficLightDevice device) => true;
	}
}