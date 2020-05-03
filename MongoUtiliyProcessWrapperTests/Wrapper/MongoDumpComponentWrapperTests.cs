using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MongoUtiliyProcessWrapper.Tests {
	[TestClass()]
	public class MongoDumpComponentWrapperTests {

		[TestMethod()]
		public void GivenExcludePrefixesWhenGetProcessStartInfoMethodCalledReturnedEntityContainsCorrectInfo() {
			var excludeColPrefix1 = "collectionPrefix";
			var excludeColPrefix2 = Guid.NewGuid().ToString("N");

			var excludeArg1 = $"--excludeCollectionsWithPrefix={excludeColPrefix1} ";
			var excludeArg2 = $"--excludeCollectionsWithPrefix={excludeColPrefix2} ";
			var testArgs = new List<string> { excludeArg1, excludeArg2 };

			MongoDumpComponentWrapper wrapper = new MongoDumpComponentWrapper("", "") {
				ExcludeCollectionsWithNamePrefixesList = new string[] { excludeArg1, excludeArg2 },
			};

			var argsLineToTest = wrapper.GetProcessStartInfo().Arguments;

			testArgs.ForEach(testArg =>
				Assert.IsTrue(
					argsLineToTest.Contains(testArg),
					$"ProcessStartInfo.Arguments: {argsLineToTest} \nMissing arg: {testArg}"));
		}

	}
}