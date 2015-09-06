using Domain.DataAccess.Contracts.Entities;
using yesmarket.DataAccess.Repository;

namespace Domain.DataAccess.Contracts.Repository
{
    public interface INotificationRepository : IRepository<Notification>
    {
    }
}