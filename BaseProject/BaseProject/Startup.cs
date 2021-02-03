using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

using CommonUtils;

using Microsoft.Owin;

using Owin;

[assembly: OwinStartup(typeof(BaseProject.Startup))]

namespace BaseProject {

    public class Startup {

        public void Configuration(IAppBuilder app) {
            ConfigDependencyInjection(app);
        }

        private void ConfigDependencyInjection(IAppBuilder app) {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Utility
            builder.RegisterAssemblyTypes(typeof(RandomUtil).Assembly)
                .Where(t => t.Name.EndsWith("Util"))
                .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}