[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MovieShop.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MovieShop.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace MovieShop.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using MovieShop.Data;
    using MovieShop.Data.Repositories;
    using MovieShop.Services;
    using MovieShop.Sevices;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //This methof provides us the way to inject implementations fro Interfaces in our project
            //This is one place where you can easily replace implementations
            kernel.Bind<IMovieService>().To<MovieService>();
            kernel.Bind<IMovieRepository>().To<MovieRepository>();
            kernel.Bind<IGenreService>().To<GenreService>();
            kernel.Bind<IGenreRepository>().To<GenreRepository>();

            kernel.Bind<ICastService>().To<CastService>();
            kernel.Bind<ICastRepository>().To<CastRepository>();


        }
    }
}
