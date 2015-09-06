using System;
using yesmarket.DataAccess.Entities;

namespace Domain.DataAccess.Contracts.Entities
{
    public class Reference : BaseEntity<Guid>
    {
        public virtual Recipient Recipient { get; set; }
        public virtual string Number { get; set; }
    }
}