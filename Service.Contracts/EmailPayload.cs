using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service.Contracts
{
	[DataContract]
	public class EmailPayload : Payload
	{
		[DataMember]
        public IList<string> AttachmentPaths { get; set; }

		[DataMember]
        public IList<string> Bcc { get; set; }

		[DataMember]
        public IList<string> CC { get; set; }

		[DataMember]
		public string From { get; set; }

		[DataMember]
		public bool IsBodyHtml { get; set; }

		[DataMember]
        public IList<string> ReplyToList { get; set; }

		[DataMember]
		public string Subject { get; set; }

		[DataMember]
        public IList<string> To { get; set; }
	}
}