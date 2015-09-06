using System;
using System.Web;
using NLog;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using yesmarket.Initialisation;
using yesmarket.SimpleInjectorExtensions;

namespace Service.Host
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var container = new Container();

            //Package registration;
            container.RegisterPackages();

            //ILogger registration;
            container.RegisterWithContext<ILogger>(context => LogManager.GetLogger(context.ImplementationType.Name));
            
            //WCF integration;
            SimpleInjectorServiceHostFactory.SetContainer(container);

            //Service initialisation;
            var initialiser = container.GetInstance<IInitialiser>();
            initialiser.Initialise();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}