using System;
using yesmarket.DataAccess.Entities;

namespace Domain.DataAccess.Contracts.Entities
{
    public class Attempt : BaseEntity<Guid>
    {
        public virtual Notification Notification { get; set; }
        public virtual DateTime DateAttempted { get; set; }
    }
}