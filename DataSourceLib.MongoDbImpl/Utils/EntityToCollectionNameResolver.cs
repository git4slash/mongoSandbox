using System;
using System.Collections.Generic;
using POCOLib;

namespace DataSourceLib.MongoDbImpl {
	public static class EntityToCollectionNameResolver {
		public static string GetCollectionName(BaseEntity entity) =>
			getCollectionName(typeof(BaseEntity), entity.Id);

		private static string getCollectionName(Type type, Guid id) {
			var colName = typeToCollectionNameMap[type];
			return isCollectionNameEndedWithId(type) ? $"{colName}{nameToPrefixSplitter}{id:N}" : colName;
		}

		public static string GetCollectionName<TEntity>(Guid id) where TEntity : BaseEntity =>
			getCollectionName(typeof(TEntity), id);

		private static readonly Dictionary<Type, string> typeToCollectionNameMap =
			new Dictionary<Type, string>
				{ { typeof(TrafficLightState),  CollectionNamePrefixes.TrafficLightState },
				  { typeof(TrafficLightDevice), CollectionNamePrefixes.TrafficLightDevice } };

		private static bool isCollectionNameEndedWithId(Type type) => prefixedWithId.Contains(type);

		private static readonly IList<Type> prefixedWithId =
			new Type[] { typeof(TrafficLightState), typeof(TrafficLightDevice) };

		public static Guid GetCollectionNameSuffix(string colName, string typeName) =>
			Guid.Parse(colName.Split(nameToPrefixSplitter)[1]);

		private const char nameToPrefixSplitter = '_';

		public static class CollectionNamePrefixes {
			public const string TrafficLightState = "TrafficLightState";
			public const string TrafficLightDevice = "Device";

		}
	}
}
