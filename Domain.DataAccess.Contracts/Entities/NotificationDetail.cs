using System;
using yesmarket.DataAccess.Entities;

namespace Domain.DataAccess.Contracts.Entities
{
	public class NotificationDetail : BaseEntity<Guid>
	{
		public virtual Notification Notification { get; set; }
		public virtual string Uri { get; set; }
	}
}