using System.Collections.Generic;

namespace Domain.Contracts
{
    public class SmsPayload : Payload
    {
        public IList<string> Numbers { get; set; }
        public string Region { get; set; }
        public string Provider { get; set; }

        public override PayloadType GetPayloadType()
        {
            return PayloadType.SMS;
        }

        public override IEnumerable<string> GetRecipients()
        {
            return Numbers;
        }

        public override string GetProvider()
        {
            return Provider;
        }
    }
}