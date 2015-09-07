using yesmarket.Mapping;
using DataContracts = Service.Contracts;
using DomainObjects = Domain.Contracts;

namespace Service.Host.Mapping
{
    public interface INotificationMapper : IDataContractMapper<DataContracts.Notification, DomainObjects.Notification>
    {
    }
}