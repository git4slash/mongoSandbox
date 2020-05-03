using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MongoUtiliyProcessWrapper.Tests {
	[TestClass()]
	public class MongoDumpRestoreAbstractWrapperTests {

		private readonly MongoDumpRestoreAbstractWrapper TestObj = new MongoDumpComponentWrapper("", "");

		[TestMethod()]
		public void GivenBackupFilePathWhenGetProcessStartInfoMethodCalledResultIsCorrect() {
			string defaultBackupFilePath = Path.Combine(Path.GetTempPath(), "mongodump.gzip");
			string backupFilePath2 = "SomePathString";

			new List<string> { defaultBackupFilePath, backupFilePath2 }
				.ForEach(filePath => {
					this.TestObj.BackupFilePath = filePath;
					var argsLine = this.TestObj.GetProcessStartInfo().Arguments;
					var filePathArg = MongoDumpRestoreAbstractWrapper.FormatBackupFileArg(filePath);
					Assert.IsTrue(argsLine.Contains(filePathArg),
								$"Invalid archive arg: {filePath}" +
								$"\nGetProcessStart.Arguments: {argsLine}");
				});
		}

		[TestMethod()]
		public void GivenTestObjCorrect_WhenGetProcessStartInfoMethodCalled_ThenArgumentsContainsDefaultArgs() {
			var defaultArg1 = "--gzip";
			var defaultArg2 = "-v";

			var argsLine = this.TestObj.GetProcessStartInfo().Arguments;
			new List<string> { defaultArg1, defaultArg2 }
				.ForEach(arg => {
					Assert.IsTrue(argsLine.Contains(arg),
								$"Arguments does not contain default arg {arg}\n	GetProcessStart.Arguments: {argsLine}");
				});
		}
	}
}