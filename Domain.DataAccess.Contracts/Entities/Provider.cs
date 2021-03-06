using System;
using yesmarket.DataAccess.Entities;

namespace Domain.DataAccess.Contracts.Entities
{
    public class Provider : BaseEntity<Guid>
    {
        public virtual Notification Notification { get; set; }
        public virtual string Name { get; set; }
    }
}