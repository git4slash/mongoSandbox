using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MongoUtiliyProcessWrapper.Tests {
	[TestClass()]
	public class MongoRestoreComponentWrapperTests {

		private MongoRestoreComponentWrapper TestObj = new MongoRestoreComponentWrapper("", "");

		[TestMethod()]
		public void GivenDropEachCollectionBeforeImportTrue_WhenGetProcessStartInfoCalled_ThenResultIsCorrect() {

			TestObj.DropEachCollectionBeforeImport = true;
			var argsLine = TestObj.GetProcessStartInfo().Arguments;

			Assert.IsTrue(argsLine.Contains(MongoRestoreComponentWrapper.DropArg),
						$"ProcessStartInfo.Arguments don't contain {MongoRestoreComponentWrapper.DropArg}");
		}

		[TestMethod()]
		public void GivenDropEachCollectionBeforeImportFalse_WhenGetProcessStartInfoCalled_ThenResultIsCorrect() {

			TestObj.DropEachCollectionBeforeImport = false;
			var argsLine = TestObj.GetProcessStartInfo().Arguments;

			Assert.IsFalse(argsLine.Contains(MongoRestoreComponentWrapper.DropArg),
						$"ProcessStartInfo.Arguments should not contain {MongoRestoreComponentWrapper.DropArg}");
		}
	}
}