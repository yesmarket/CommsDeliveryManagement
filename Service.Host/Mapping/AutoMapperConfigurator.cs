using AutoMapper;
using yesmarket.Mapping;
using DataContracts = Service.Contracts;
using DomainObjects = Domain.Contracts;

namespace Service.Host.Mapping
{
    public class AutoMapperConfigurator : IAutoMappingConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<DataContracts.Payload, DomainObjects.Payload>()
                .Include<DataContracts.EmailPayload, DomainObjects.EmailPayload>()
                .Include<DataContracts.SmsPayload, DomainObjects.SmsPayload>();
            Mapper.CreateMap<DataContracts.EmailPayload, DomainObjects.EmailPayload>();
            Mapper.CreateMap<DataContracts.SmsPayload, DomainObjects.SmsPayload>();
            Mapper.CreateMap<DataContracts.Notification, DomainObjects.Notification>();
        }
    }
}
