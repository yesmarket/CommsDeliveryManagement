using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service.Contracts
{
    [DataContract]
    public class Notification
    {
        [DataMember]
        public Payload Payload { get; set; }

        [DataMember]
        public IDictionary<string, string> Details { get; set; }

        [DataMember]
        public bool QueueDelivery { get; set; }
    }
}