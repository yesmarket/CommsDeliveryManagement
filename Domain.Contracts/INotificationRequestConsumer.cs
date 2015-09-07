using System;

namespace Domain.Contracts
{
    public interface INotificationRequestConsumer
    {
        void QueueNotificationRequest(Guid notificationId, Payload payload);
    }
}