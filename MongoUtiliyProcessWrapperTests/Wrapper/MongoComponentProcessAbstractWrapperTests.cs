using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MongoUtiliyProcessWrapper.Tests {
	[TestClass()]
	public class MongoComponentProcessAbstractWrapperTests {

		private const string filePath = "filePath";
		private const string mongoDbUri = "serv:port/DB_Name";
		private MongoComponentProcessAbstractWrapper TestInstance = new MongoDumpComponentWrapper(filePath, mongoDbUri);

		[TestMethod()]
		public void GivenFileNamePath_WhenGetProcessStartInfoCalled_ThenResultIsCorrect() =>
			Assert.IsTrue(TestInstance.GetProcessStartInfo()
										.FileName
										.Equals(filePath),
						$"FileName not equal");

		[TestMethod()]
		public void GivenMongoDbUri_WhenGetProcessStartInfoMethodCalled_ThenResultIsCorrect() =>
			Assert.IsTrue(TestInstance.GetProcessStartInfo()
										.Arguments
										.Contains($"--uri={mongoDbUri}"),
						$"ProcessStartInfo don't contain uri arg");
	}
}