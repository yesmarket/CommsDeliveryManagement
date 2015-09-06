using System.Linq;
using Domain.DataAccess.Contracts.Entities;
using Domain.DataAccess.Contracts.Types;
using yesmarket.DateTimes;
using DomainObjects = Domain.Contracts;

namespace Domain.Mapping
{
    public class NotificationMapper : INotificationMapper
    {
        private readonly IDateTimeResolver _dateTimeResolver;
        private readonly IPayloadXmlSerializer _payloadXmlSerializer;

        public NotificationMapper(
            IDateTimeResolver dateTimeResolver,
            IPayloadXmlSerializer payloadXmlSerializer)
        {
            _dateTimeResolver = dateTimeResolver;
            _payloadXmlSerializer = payloadXmlSerializer;
        }

        public Notification MapFrom(DomainObjects.Notification source)
        {
            var destination =
                new Notification
                {
                    DateAdded = _dateTimeResolver.UtcNow,
                    Payload = _payloadXmlSerializer.Serialize(source.Payload),
                    Type = source.Payload.GetPayloadType().ToString()
                };

            var providerName = source.Payload.GetProvider();
            if (!string.IsNullOrEmpty(providerName))
            {
                var provider =
                    new Provider
                    {
                        Name = providerName
                    };

                destination.AssignProvider(provider);
            }

            if (source.Details != null)
            {
                foreach (var metadata in source.Details)
                {
                    var details =
                        new NotificationDetail
                        {
                            Uri = string.Format("{0}:{1}", metadata.Key, metadata.Value)
                        };

                    destination.AddDetail(details);
                }
            }

            var recipients = source.Payload.GetRecipients().ToList();
            foreach (var r in recipients)
            {
                var recipient = new Recipient
                {
                    Token = r,
                    Status = Status.Pending
                };

                destination.AddRecipient(recipient);
            }

            return destination;
        }
    }
}