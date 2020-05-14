using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using TrafficLigthControllers;

namespace TrafficLightsGUI {
	internal static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main() {
			fillDevices();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			BonusSkins.Register();
			Application.Run(new MainView());
		}

		private static void fillDevices() {
			var rand = new Random();
			new TrafficLightDevicesController()
				.SaveMany(Enumerable.Range(0, 10).Select(_ => new POCOLib.TrafficLightDevice { Name = $"Device# {rand.Next(0, 1000)}" }));
		}
	}
}