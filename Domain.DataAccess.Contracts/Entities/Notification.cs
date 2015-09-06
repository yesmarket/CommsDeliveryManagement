using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using yesmarket.DataAccess.Entities;

namespace Domain.DataAccess.Contracts.Entities
{
    public class Notification : BaseEntity<Guid>
    {
        private readonly ICollection<Attempt> _attempts = new Collection<Attempt>();
        private readonly ICollection<NotificationDetail> _details = new Collection<NotificationDetail>();
        private readonly ICollection<Recipient> _recipients = new Collection<Recipient>();
        public virtual DateTime DateAdded { get; set; }
        public virtual string Type { get; set; }
        public virtual XElement Payload { get; set; }

        public virtual ICollection<Recipient> Recipients
        {
            get { return _recipients; }
        }

        public virtual ICollection<NotificationDetail> Details
        {
            get { return _details; }
        }

        public virtual ICollection<Attempt> Attempts
        {
            get { return _attempts; }
        }

        public virtual Provider Provider { get; set; }

        #region Convenience methods

        public virtual void AddRecipient(Recipient recipient)
        {
            recipient.Notification = this;
            Recipients.Add(recipient);
        }

        public virtual void AddDetail(NotificationDetail notificationDetail)
        {
            notificationDetail.Notification = this;
            Details.Add(notificationDetail);
        }

        public virtual void AddAttempt(Attempt attempt)
        {
            attempt.Notification = this;
            Attempts.Add(attempt);
        }

        public virtual void AssignProvider(Provider provider)
        {
            provider.Notification = this;
            Provider = provider;
        }

        #endregion
    }
}