using System;
using Domain.Contracts;
using NLog;

namespace Domain
{
    public class CommsDeliveryManager : ICommsDeliveryManager
    {
        private readonly ILogger _logger;

        public CommsDeliveryManager(
            ILogger logger)
        {
            _logger = logger;
        }

        public Guid Notify(Notification notification)
        {
            //map notification to entity;
            //save notification;

            if (notification.QueueDelivery)
            {
                //put a message on the queue;
            }

            //return the identifier;
            return Guid.NewGuid();
        }
    }
}