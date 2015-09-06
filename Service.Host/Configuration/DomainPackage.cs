using Domain;
using Domain.Contracts;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Service.Host.Configuration
{
    public class DomainPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICommsDeliveryManager, CommsDeliveryManager>();
        }
    }
}