using System.Collections.Generic;

namespace Domain.Contracts
{
    public class SmsPayload : Payload
    {
        public IList<string> Numbers { get; set; }
        public string Region { get; set; }
        public string Provider { get; set; }
    }
}