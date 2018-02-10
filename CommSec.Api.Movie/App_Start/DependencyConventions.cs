using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CommSec.Api.Movie.Controllers;
using CommSec.Api.Movie.Repository;
using CommSec.Api.Movie.Services;

namespace Blast.Api.Web
{
    public class DependencyConventions : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<MoviesController>().LifestylePerWebRequest())
                .Register(Component.For<IMovieRepo>().ImplementedBy<MovieRepo>())
                .Register(Component.For<IMovieHelper>().ImplementedBy<MovieHelper>());
        }
    }
}