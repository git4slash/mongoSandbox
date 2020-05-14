using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using POCOLib;
using System.Linq;

namespace TrafficLightsGUI.Views
{
    [POCOViewModel]
    public class TrafficlightStatusGridViewModel {
        private TrafficLightDevice _device;

        protected TrafficlightStatusGridViewModel(TrafficLightDevice device) {
            this._device = device;
        }

        public static TrafficlightStatusGridViewModel Create(TrafficLightDevice device) =>
            ViewModelSource.Create(() => new TrafficlightStatusGridViewModel(device));

        public virtual IQueryable<TrafficLightState> TrafficLightStates { get; set; }
    }
}