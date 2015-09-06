using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service.Contracts
{
    [DataContract]
    public class SmsPayload : Payload
    {
        [DataMember]
        public IList<string> Numbers { get; set; }

        [DataMember]
        public string Region { get; set; }

        [DataMember]
        public string Provider { get; set; }
    }
}
