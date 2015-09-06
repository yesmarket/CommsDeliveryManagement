using System;
using yesmarket.Entities;

namespace Domain.DataAccess.Contracts.Entities
{
    public class Reference : BaseEntity<Guid>
    {
        public virtual Recipient Recipient { get; set; }
        public virtual string Number { get; set; }
    }
}