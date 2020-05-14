using System;

namespace POCOLib {
	public class TrafficLightState : BaseEntity {

		public DateTime TimeStamp { get; set; }

		public Light State { get; set; }

		public TrafficLightState(DateTime timeStamp, Light state) {
			this.TimeStamp = timeStamp;
			this.State = state;
		}

		public enum Light {
			Green,
			Yellow,
			Red
		}
	}
}
