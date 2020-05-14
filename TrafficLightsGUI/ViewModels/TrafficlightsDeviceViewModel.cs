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
        }

        public static TrafficlightsDeviceViewModel Create() =>
            ViewModelSource.Create(() => new TrafficlightsDeviceViewModel());

        public virtual IQueryable<TrafficLightDevice> Devices {
			get => this._devicesController.GetAllDevices(d => true);
			set => this._devices = value;
		}

        public virtual TrafficLightDevice SelectedDevice { get; set; }

        public void OnSelectedDeviceChanged() => 
            this.RaiseCanExecuteChanged(x => RemoveSelectedDevice());

		public void AddDevice() {
			this._devicesController.Save(GeneratorViewModel.GetGeneratedDevice());
			this.NotifyDevicesChanged();
		}

		public void NotifyDevicesChanged() => this.RaisePropertyChanged(x => x.Devices);

		public bool CanAddDevice() => this._devicesController != null;

        public void RemoveSelectedDevice() {
            if (MessageBoxService.ShowMessage("Are you sure?",
                                            "Question",
                                            MessageButton.YesNo,
                                            MessageIcon.Question,
                                            MessageResult.No) == MessageResult.Yes) {
                this._devicesController.Delete(SelectedDevice);
				this.NotifyDevicesChanged();
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
		private IQueryable<TrafficLightDevice> _devices;
	}
}
