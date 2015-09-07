using System;
using System.ServiceModel;
using yesmarket.Wcf;
using yesmarket.Wcf.FaultContracts;

namespace Service.Contracts
{
    [ServiceContract]
    public interface ICommsDeliveryService
    {
        [OperationContract]
        [ServiceKnownType("RegisterKnownTypes", typeof(ServiceKnownTypeResolver<Payload>))]
        [FaultContract(typeof(Fault))]
        [FaultContract(typeof(ValidationFault))]
        Guid Notify(Notification notification, bool bypassQueuing = false);
    }
}
