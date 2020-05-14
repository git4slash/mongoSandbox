using System;
using System.Collections.Generic;

namespace MongoUtiliyProcessWrapper.MessageParser {
	public class MongodumpMessageParser : IProcessMessageParser {
		public MongodumpMessageParser() {}

		public MongodumpMessage ParseMessage(string message) {
			throw new NotImplementedException();
		}

		//2020-04-30T13:44:26.360+0200    archive prelude MeasurementCenterDB.3e7805c7d60644e087ff2629eaf52137DeviceDataSyncStateEntryDeviceDataSyncStateEntries
		//2020-04-30T13:44:26.371+0200    dumping up to 4 collections in parallel
		//2020-04-30T13:44:26.371+0200    writing MeasurementCenterDB.f207ede0d0b311e8840a0001c01ec727AnalogDataEntry-059-04 to archive 'C:\Temp\0_mongoDump\backup.gzip'
		//2020-04-30T13:44:28.135+0200    [############............]  MeasurementCenterDB.f207ede0d0b311e8840a0001c01ec727AnalogDataEntry-059-04  372826/726239  (51.3%)
		//2020-04-30T13:44:40.775+0200    done dumping MeasurementCenterDB.f207ede0d0b311e8840a0001c01ec727AnalogDataEntry-059-04 (726239 documents)
		public List<string> queuedCollection = new List<string>();
		public List<string> processedCollection = new List<string>();

		//public Regex collectionToDumpRegex = $"{}";
	}

	public enum MongodumpMessageType {
		CollectionToDump,               // archive prelude
		NumberOfCollectionsInParallel, // dumping up to {number} collections in parallel
		StartCollectionDump,            // writing MeasurementCenterDB.f207ede0d0b311e8840a0001c01ec727AnalogDataEntry-059-04 to archive 'C:\Temp\0_mongoDump\backup.gzip'
		ProgressCollectionDump,         // [############............]  MeasurementCenterDB.f207ede0d0b311e8840a0001c01ec727AnalogDataEntry-059-04  372826/726239  (51.3%)
		EndCollectionDump               // done dumping MeasurementCenterDB.f207ede0d0b311e8840a0001c01ec727AnalogDataEntry-059-04 (726239 documents)
	}

	enum MessagePart {
		DateTime,
		CollectionToParse,
		ActiveCollection
	}

	public class MongodumpMessage {
		public Dictionary<MongodumpMessageType, List<string>> TypeToPartsMap = new Dictionary<MongodumpMessageType, List<string>>();
	}
}
