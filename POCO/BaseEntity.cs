using System;

namespace POCOLib {
	public abstract class BaseEntity {
        private Guid _id = Guid.NewGuid();

        public Guid Id {
            get => this._id;
            set => this._id = value; }
	}
}