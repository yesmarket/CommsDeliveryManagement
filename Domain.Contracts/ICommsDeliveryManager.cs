using System;

namespace Domain.Contracts
{
    public interface ICommsDeliveryManager
    {
        Guid Notify(Notification notification);
    }
}
