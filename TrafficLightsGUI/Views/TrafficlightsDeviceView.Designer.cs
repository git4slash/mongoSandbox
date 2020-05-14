namespace TrafficLightsGUI.Views
{
    partial class TrafficlightsDeviceView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.trafficlightDevicesGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.addDeviceSimpleButton = new DevExpress.XtraEditors.SimpleButton();
			this.removeDeviceSimpleButton = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trafficlightDevicesGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// mvvmContext1
			// 
			this.mvvmContext1.BindingExpressions.AddRange(new DevExpress.Utils.MVVM.BindingExpression[] {
            DevExpress.Utils.MVVM.BindingExpression.CreatePropertyBinding(typeof(TrafficLightsGUI.ViewModels.TrafficlightsDeviceViewModel), "Devices", this.gridControl1, "DataSource")});
			this.mvvmContext1.ContainerControl = this;
			this.mvvmContext1.RegistrationExpressions.AddRange(new DevExpress.Utils.MVVM.RegistrationExpression[] {
            DevExpress.Utils.MVVM.RegistrationExpression.RegisterMessageBoxService(null, false, DevExpress.Utils.MVVM.Services.DefaultMessageBoxServiceType.Default),
            DevExpress.Utils.MVVM.RegistrationExpression.RegisterDocumentManagerService(null, false, null)});
			this.mvvmContext1.ViewModelType = typeof(TrafficLightsGUI.ViewModels.TrafficlightsDeviceViewModel);
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.MainView = this.trafficlightDevicesGridView;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(800, 600);
			this.gridControl1.TabIndex = 0;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.trafficlightDevicesGridView});
			// 
			// trafficlightDevicesGridView
			// 
			this.trafficlightDevicesGridView.GridControl = this.gridControl1;
			this.trafficlightDevicesGridView.Name = "trafficlightDevicesGridView";
			this.trafficlightDevicesGridView.OptionsView.ShowFooter = true;
			// 
			// addDeviceSimpleButton
			// 
			this.addDeviceSimpleButton.Location = new System.Drawing.Point(196, 480);
			this.addDeviceSimpleButton.Name = "addDeviceSimpleButton";
			this.addDeviceSimpleButton.Size = new System.Drawing.Size(75, 23);
			this.addDeviceSimpleButton.TabIndex = 1;
			this.addDeviceSimpleButton.Text = "Add Device";
			// 
			// removeDeviceSimpleButton
			// 
			this.removeDeviceSimpleButton.Location = new System.Drawing.Point(301, 480);
			this.removeDeviceSimpleButton.Name = "removeDeviceSimpleButton";
			this.removeDeviceSimpleButton.Size = new System.Drawing.Size(110, 23);
			this.removeDeviceSimpleButton.TabIndex = 1;
			this.removeDeviceSimpleButton.Text = "Remove Device";
			// 
			// TrafficlightsDeviceView
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.removeDeviceSimpleButton);
			this.Controls.Add(this.addDeviceSimpleButton);
			this.Controls.Add(this.gridControl1);
			this.Name = "TrafficlightsDeviceView";
			this.Size = new System.Drawing.Size(800, 600);
			((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trafficlightDevicesGridView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView trafficlightDevicesGridView;
        private DevExpress.XtraEditors.SimpleButton removeDeviceSimpleButton;
        private DevExpress.XtraEditors.SimpleButton addDeviceSimpleButton;
    }
}
