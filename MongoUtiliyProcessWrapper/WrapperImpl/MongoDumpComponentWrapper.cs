using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MongoUtiliyProcessWrapper {

	public class MongoDumpComponentWrapper : MongoDumpRestoreAbstractWrapper {
		public MongoDumpComponentWrapper(string mongodumpPath, string mongodbURI) : base(mongodumpPath, mongodbURI) { }

		public new ProcessStartInfo GetProcessStartInfo() {
			base.Args.Add($"{this.getExcludeArgs()}");
			return base.GetProcessStartInfo();
		}

		public IEnumerable<string> ExcludeCollectionsWithNamePrefixesList { get; set; }

		private string getExcludeArgs() =>
			this.ExcludeCollectionsWithNamePrefixesList != null && this.ExcludeCollectionsWithNamePrefixesList.Any() ?
			string.Join(string.Empty, this.ExcludeCollectionsWithNamePrefixesList.Select(excl => $"--excludeCollectionsWithPrefix={excl} ")) :
			string.Empty;
	}
}
