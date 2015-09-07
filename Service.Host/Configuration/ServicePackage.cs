using FluentValidation;
using Service.Contracts;
using Service.Host.Mapping;
using Service.Host.Validation;
using SimpleInjector;
using SimpleInjector.Packaging;
using yesmarket.Initialisation;
using yesmarket.Mapping;

namespace Service.Host.Configuration
{
    public class ServicePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            //mappings;
            container.Register<IAutoMappingConfigurator, AutoMapperConfigurator>();
            container.Register<INotificationMapper, NotificationMapper>();

            //validators;
            container.Register<SmsPayloadValidator>();
            container.Register<EmailPayloadValidator>();
            container
                .Register<IValidator<Payload>>(() => new PolymorphicValidator<Payload>()
                    .RegisterDerived(container.GetInstance<SmsPayloadValidator>())
                    .RegisterDerived(container.GetInstance<EmailPayloadValidator>()));
            container.Register<IValidator<Notification>, NotificationValidator>();

            //services;
            container.Register<ICommsDeliveryService, CommsDeliveryService>();

            container.Register<IInitialiser, ServiceInitialiser>();
        }
    }
}