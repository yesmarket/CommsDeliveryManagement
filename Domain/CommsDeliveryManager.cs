using System;
using Domain.Contracts;
using Domain.DataAccess.Contracts.Repository;
using Domain.Mapping;
using NLog;
using yesmarket.DataAccess.UnitOfWork;

namespace Domain
{
    public class CommsDeliveryManager : ICommsDeliveryManager
    {
        private readonly ILogger _logger;
        private readonly INotificationMapper _notificationMapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationRequestConsumer _notificationRequestConsumer;
        private readonly IUnitOfWork _unitOfWork;

        public CommsDeliveryManager(
            ILogger logger,
            INotificationMapper notificationMapper,
            IUnitOfWork unitOfWork,
            INotificationRepository notificationRepository,
            INotificationRequestConsumer notificationRequestConsumer)
        {
            _logger = logger;
            _notificationMapper = notificationMapper;
            _unitOfWork = unitOfWork;
            _notificationRepository = notificationRepository;
            _notificationRequestConsumer = notificationRequestConsumer;
        }

        public Guid Notify(Notification notification, bool bypassQueuing = false)
        {
            _logger.Info("Saving notification.");

            var notificationEntity = _notificationMapper.MapFrom(notification);

            var id = new Guid();
            _unitOfWork.Do(() =>
            {
                id = (Guid) _notificationRepository.Save(notificationEntity);
                _notificationRequestConsumer.QueueNotificationRequest(id, notification.Payload);
            });

            _logger.Info("Notification saved with Id #{0}", id);

            return id;
        }
    }
}