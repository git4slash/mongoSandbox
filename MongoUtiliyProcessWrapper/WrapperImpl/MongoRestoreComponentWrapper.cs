namespace MongoUtiliyProcessWrapper {
	public class MongoRestoreComponentWrapper : MongoDumpRestoreAbstractWrapper {
		public MongoRestoreComponentWrapper(string mongorestorePath, string mongodbURI) : base(mongorestorePath, mongodbURI) {
			DropEachCollectionBeforeImport = true;
		}

		public bool DropEachCollectionBeforeImport {
			get => dropEachCollectionBeforeImport;
			set {
				dropEachCollectionBeforeImport = value;
				if ( dropEachCollectionBeforeImport && !Args.Contains(DropArg) ) {
					base.Args.Add(DropArg);
				} else if ( !dropEachCollectionBeforeImport ) {
					Args.Remove(DropArg);
				}
			}
		}

		public const string DropArg = "--drop";
		private bool dropEachCollectionBeforeImport;
	}
}
