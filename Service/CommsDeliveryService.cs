using System;
using FluentValidation;
using NLog;
using Service.Mapping;
using DataContracts = Service.Contracts;
using DomainObjects = Domain.Contracts;

namespace Service
{
    public class CommsDeliveryService : DataContracts.ICommsDeliveryService
    {
        private readonly DomainObjects.ICommsDeliveryManager _commsDeliveryManager;
        private readonly ILogger _logger;
        private readonly INotificationMapper _notificationMapper;
        private readonly IValidator<DataContracts.Notification> _notificationValidator;

        public CommsDeliveryService(
            ILogger logger,
            IValidator<DataContracts.Notification> notificationValidator,
            INotificationMapper notificationMapper,
            DomainObjects.ICommsDeliveryManager commsDeliveryManager)
        {
            _logger = logger;
            _notificationValidator = notificationValidator;
            _notificationMapper = notificationMapper;
            _commsDeliveryManager = commsDeliveryManager;
        }

        public Guid Notify(DataContracts.Notification notification)
        {
            try
            {
                _logger.Info("Received notification.");

                _notificationValidator.ValidateAndThrow(notification);

                var ndo = _notificationMapper.MapToDomainObject(notification);
                var identifier = _commsDeliveryManager.Notify(ndo);

                return identifier;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                throw;
            }
        }
    }
}