using System;
using System.Diagnostics;
using System.IO;
using MongoUtiliyProcessWrapper;

namespace MongoSandbox {
	public class TryMongoDumpRestoreWrappersApp {

		static void Main(string[] args) {
			//testMongoDumpWrapper();
			testMongoRestoreWrapper();
		}

		private static void testMongoDumpWrapper() {
			var backupDir = Path.Combine(Path.GetTempPath(), "0_mongoDump");
			if ( !Directory.Exists(backupDir) ) {
				try {
					Directory.CreateDirectory(backupDir);
				} catch ( Exception ex ) {
					Console.Error.WriteLine($"Can't create backup folder!\npath: {backupDir}");
					throw ex;
				}
			}

			//var dumpProcess = new MongoDumpComponentWrapper(DefaultMongoDumpPath, DefaultMongoDbUri) {
			var dumpProcess = new MongoDumpComponentWrapper(DefaultMongoDumpPath, Db2) {
				BackupFilePath = Path.Combine(backupDir, "backup.gzip"),
				//OnProcessMessage = msgToConsole,
				OnProcessErrorMessage = msgToConsole
			}
				.GetProcess();

			dumpProcess.WaitForExit();
			Console.WriteLine("Dump complete\nPress any key to continue");
			Console.ReadKey();
		}

		private static void msgToConsole(object arg1, DataReceivedEventArgs arg2) => Console.WriteLine(arg2.Data);

		private static void testMongoRestoreWrapper() {
			var backupDir = Path.Combine(Path.GetTempPath(), "0_mongoDump");

			new MongoRestoreComponentWrapper(DefaultMongoRestorePath, DefaultMongoDbUri) {
				BackupFilePath = Path.Combine(backupDir, "backup.gzip"),
				OnProcessErrorMessage = msgToConsole
			}
				.GetProcess()
				.WaitForExit();

			Console.WriteLine("Restore complete\nPress any key to exit");
			Console.ReadKey();
		}

		public const string DefaultMongoDumpPath = "c:\\Program Files\\MongoDB\\Server\\3.4\\bin\\mongodump.exe";
		public const string DefaultMongoRestorePath = "c:\\Program Files\\MongoDB\\Server\\3.4\\bin\\mongorestore.exe";
		public const string DefaultMongoDbUri = "mongodb://localhost:27317/DumpRestoreTestDb";
		public const string Db2 = "mongodb://localhost:27317/MeasurementCenterDB";
	}
}
