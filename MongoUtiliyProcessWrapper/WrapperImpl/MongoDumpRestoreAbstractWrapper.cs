using System.IO;

namespace MongoUtiliyProcessWrapper {
	public abstract class MongoDumpRestoreAbstractWrapper : MongoComponentProcessAbstractWrapper {

		protected MongoDumpRestoreAbstractWrapper(string componentPath, string mongodbURI) : base(componentPath, mongodbURI) {
			base.Args.AddRange(
				new string[] {"--gzip",
							"-v" });
		}

		public string BackupFilePath {
			get => backupFile;
			set {
				if ( value == backupFile )
					return;
				base.Args.Remove(FormatBackupFileArg(backupFile));
				this.backupFile = value;
				base.Args.Add(FormatBackupFileArg(backupFile));
			} }

		private string backupFile;
		public static string FormatBackupFileArg(string backupFilePath) =>
			$"--archive={backupFilePath}";
	}
}
