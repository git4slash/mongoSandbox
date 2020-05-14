using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using POCOLib;
using System;
using System.Linq;
using TrafficLigthControllers;

namespace TrafficLightsGUI.ViewModels
{
    [POCOViewModel]
    public class GeneratorViewModel {
        private readonly TrafficLightDevicesController _devicesController;
        private readonly Random _random;

        protected GeneratorViewModel(){
            this._devicesController = new TrafficLightDevicesController();
            this._random = new Random();
        }

        public static GeneratorViewModel Create() =>
            ViewModelSource.Create(() => new GeneratorViewModel());

        public void GenerateDevice() => this._devicesController.Save(generateDevice());
        public bool CanGenerateDevice() => true;

        public void GenarateState(TrafficLightDevice device) {
            //Enumerable.Range(0, 1000)
                //.Select(generateState);
        }

        private static TrafficLightState generateState() =>
            new TrafficLightState(DateTime.Now, TrafficLightState.Light.Green);
        private TrafficLightDevice generateDevice() => 
            new TrafficLightDevice {
                Id = Guid.NewGuid(),
                Name = $"Device# { _random.Next(0, 1000) }"
            };

        public bool CanGenerateState(TrafficLightDevice device) => true;
    }
}