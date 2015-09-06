using yesmarket.Mapping;
using DomainObjects = Domain.Contracts;
using Entities = Domain.DataAccess.Contracts.Entities;

namespace Domain.Mapping
{
    public interface INotificationMapper : IMapper<DomainObjects.Notification, Entities.Notification>
    {
    }
}