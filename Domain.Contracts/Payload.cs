using System.Collections.Generic;

namespace Domain.Contracts
{
    public abstract class Payload
    {
        public string Message { get; set; }
        public abstract PayloadType GetPayloadType();
        public abstract IEnumerable<string> GetRecipients();

        public virtual string GetProvider()
        {
            return null;
        }
    }
}