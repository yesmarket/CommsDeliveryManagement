using System.Collections.Generic;

namespace Domain.Contracts
{
    public class EmailPayload : Payload
    {
        public IList<string> AttachmentPaths { get; set; }
        public IList<string> Bcc { get; set; }
        public IList<string> CC { get; set; }
        public string From { get; set; }
        public bool IsBodyHtml { get; set; }
        public IList<string> ReplyToList { get; set; }
        public string Subject { get; set; }
        public IList<string> To { get; set; }
    }
}