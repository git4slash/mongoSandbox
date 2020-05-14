using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using POCOLib;
using TrafficLightsGUI.ViewModels;

namespace TrafficLightsGUI.Views
{
    public partial class TrafficlightsDeviceView : DevExpress.XtraEditors.XtraUserControl
    {
        public TrafficlightsDeviceView() {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();

			this.trafficlightDevicesGridView.OptionsBehavior.Editable = false;
        }

        void InitializeBindings() {

            var devicesFluent = mvvmContext1.OfType<TrafficlightsDeviceViewModel>();
			
			// Selected device changed
			devicesFluent.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(this.trafficlightDevicesGridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedDevice,
                            args => args.Row as TrafficLightDevice,
                            (gView, device) => gView.FocusedRowHandle = gView.FindRow(device));

			// Double click on device
			devicesFluent.WithEvent<RowClickEventArgs>(this.trafficlightDevicesGridView, "RowClick")
                .EventToCommand(x => x.ShowStatus(null),
                                x => x.SelectedDevice,
                                args => (args.Clicks == 2) && (args.Button == System.Windows.Forms.MouseButtons.Left));

			// Remove selected device
			devicesFluent.BindCommand(this.removeDeviceSimpleButton, x => x.RemoveSelectedDevice());

			// Generate than save device
			devicesFluent.BindCommand(this.addDeviceSimpleButton, x => x.AddDevice());

        }
    }
}
