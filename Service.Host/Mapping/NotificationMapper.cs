using AutoMapper;
using DataContracts = Service.Contracts;
using DomainObjects = Domain.Contracts;

namespace Service.Host.Mapping
{
    public class NotificationMapper : INotificationMapper
    {
        public DomainObjects.Notification MapToDomainObject(DataContracts.Notification source)
        {
            return Mapper.Map<DataContracts.Notification, DomainObjects.Notification>(source);
        }

        public DataContracts.Notification MapToDataContract(DomainObjects.Notification source)
        {
            return Mapper.Map<DomainObjects.Notification, DataContracts.Notification>(source);
        }
    }
}
