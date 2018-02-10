using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommSec.Api.Movie.Repository;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CommSec.Api.Movie
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            var container = new WindsorContainer();
            container.Register(Component.For<IMovieRepo>().ImplementedBy<MovieRepo>());
        }
    }
}
