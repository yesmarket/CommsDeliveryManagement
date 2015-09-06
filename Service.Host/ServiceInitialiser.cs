using AutoMapper;
using yesmarket.Initialisation;
using yesmarket.Mapping;

namespace Service.Host
{
    public class ServiceInitialiser : IInitialiser
    {
        private readonly IAutoMappingConfigurator _autoMappingConfigurator;

        public ServiceInitialiser(
            IAutoMappingConfigurator autoMappingConfigurator)
        {
            _autoMappingConfigurator = autoMappingConfigurator;
        }

        public void Initialise()
        {
            _autoMappingConfigurator.Configure();
            Mapper.AssertConfigurationIsValid();
        }
    }
}