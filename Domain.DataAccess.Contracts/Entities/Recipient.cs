using System;
using Domain.DataAccess.Contracts.Types;
using yesmarket.DataAccess.Entities;

namespace Domain.DataAccess.Contracts.Entities
{
	public class Recipient : BaseEntity<Guid>
	{
		public virtual Notification Notification { get; set; }
		public virtual string Token { get; set; }
		public virtual Status Status { get; set; }
		public virtual DateTime? DateSent { get; set; }
        public virtual Reference Reference { get; set; }

        #region Convenience methods

        public virtual void AssignReference(Reference reference)
        {
            reference.Recipient = this;
            Reference = reference;
        } 

        #endregion
	}
}