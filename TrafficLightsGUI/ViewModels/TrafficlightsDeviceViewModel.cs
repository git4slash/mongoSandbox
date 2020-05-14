using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using POCOLib;
using System.Linq;
using TrafficLightsGUI.Views;
using TrafficLigthControllers;

namespace TrafficLightsGUI.ViewModels
{
    [POCOViewModel()]
    public class TrafficlightsDeviceViewModel{

        protected TrafficlightsDeviceViewModel() {
            this._devicesController = new TrafficLightDevicesController();
            Devices = this._devicesController.GetAllDevices(d => true);
        }

        public static TrafficlightsDeviceViewModel Create() =>
            ViewModelSource.Create(() => new TrafficlightsDeviceViewModel());

        public virtual IQueryable<TrafficLightDevice> Devices { get; set; }
        public virtual TrafficLightDevice SelectedDevice { get; set; }

        public void OnSelectedDeviceChanged() => 
            this.RaiseCanExecuteChanged(x => RemoveSelectedDevice());

        public void AddDevice(TrafficLightDevice device) =>
            this._devicesController.Save(device);
        public bool CanAddDevice(TrafficLightDevice device) =>
            device != null && this._devicesController != null;

        public void RemoveSelectedDevice() {
            if (MessageBoxService.ShowMessage("Are you sure?",
                                            "Question",
                                            MessageButton.YesNo,
                                            MessageIcon.Question,
                                            MessageResult.No) == MessageResult.Yes) {
                this._devicesController.Delete(SelectedDevice);
            }
        }
        public bool CanRemoveSelectedDevice() => SelectedDevice != null;

        internal void ShowStatus(object p) =>
            DocumentManagerService.CreateDocument(nameof(TrafficlightStatusGridView),
                                                TrafficlightStatusGridViewModel.Create(p as TrafficLightDevice))
                    .Show();

        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IMessageBoxService MessageBoxService => null;

        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService => null;

        private readonly TrafficLightDevicesController _devicesController;
    }
}
