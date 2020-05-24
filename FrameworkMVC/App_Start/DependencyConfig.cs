using System;
using System.Web.Mvc;
using Net.Lab.Common.Implementations;
using Net.Lab.Common.Interfaces;
using Net.Lab.DAL.Repositories.Implementations;
using Net.Lab.DAL.Repositories.Interfaces;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace FrameworkMVC.App_Start
{
    public class DependencyConfig : NinjectModule
    {
        public static void RegisterDependencies()
        {
            DependencyConfig dependencies = new DependencyConfig();

            IKernel kernel = new StandardKernel(dependencies);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        public override void Load()
        {
            Bind<IGamesRepository>().To<InMemoryGamesRepository>().InSingletonScope();
            Bind<IGamesService>().To<GamesService>().InSingletonScope();
        }
    }
}