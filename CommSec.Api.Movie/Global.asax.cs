using Blast.Api.Web;
using Castle.Windsor;
using CommSec.Api.Movie.App_Start;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;

namespace CommSec.Api.Movie
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer container;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(this.container));
        }

        public WebApiApplication()
        {
            this.container = new WindsorContainer().Install(new DependencyConventions());
        }

        public override void Dispose()
        {
            this.container.Dispose();
            base.Dispose();
        }
    }
}
