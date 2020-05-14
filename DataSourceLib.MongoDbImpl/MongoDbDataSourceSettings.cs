namespace DataSourceLib.MongoDbImpl {
	public class MongoDbDataSourceSettings : Interfaces.IDataSourceSettings {
		public string ResourceUri => "mongodb://localhost:27317";
		public string ResourceName => "TrafficLightsDB";
	}
}