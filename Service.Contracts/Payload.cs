using System.Runtime.Serialization;

namespace Service.Contracts
{
    [DataContract]
    public abstract class Payload
    {
        [DataMember]
        public string Message { get; set; }
    }
}
