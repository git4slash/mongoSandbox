using System;
using System.IO;
using MongoUtiliyProcessWrapper;

namespace MongoSandbox {
	public class TryMongoDumpRestoreWrappersApp {

		static void Main(string[] args) {
			testMongoDumpWrapper();
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

			new MongoDumpComponentWrapper(DefaultMongoDumpPath, DefaultMongoDbUri) {
				BackupFilePath = Path.Combine(backupDir, "backup.gzip")
			}
				.GetProcess()
				.WaitForExit();
			Console.WriteLine("Dump complete\nPress any key to continue");
			Console.ReadKey();
		}

		private static void testMongoRestoreWrapper() {
			var backupDir = Path.Combine(Path.GetTempPath(), "0_mongoDump");

			new MongoRestoreComponentWrapper(DefaultMongoRestorePath, DefaultMongoDbUri) {
				BackupFilePath = Path.Combine(backupDir, "backup.gzip")
			}
				.GetProcess()
				.WaitForExit();

			Console.WriteLine("Restore complete\nPress any key to exit");
			Console.ReadKey();
		}

		public const string DefaultMongoDumpPath = "c:\\Program Files\\MongoDB\\Server\\3.4\\bin\\mongodump.exe";
		public const string DefaultMongoRestorePath = "c:\\Program Files\\MongoDB\\Server\\3.4\\bin\\mongorestore.exe";
		public const string DefaultMongoDbUri = "mongodb://localhost:27317/DumpRestoreTestDb";
	}
}
