using System.Collections.Generic;

namespace Domain.Contracts
{
    public class Notification
    {
        public Payload Payload { get; set; }
        public IDictionary<string, string> Details { get; set; }
    }
}