using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Spartane.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Spartane.Core.Data;
using Spartane.Data;
using Spartane.Data.EF;
using Spartane.Services.Departamento;
using Spartane.Services.Empleado;
using Spartane.Services.Archivos;
using Spartane.Services.Puesto;


namespace oAuth.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            var builder = new ContainerBuilder();

            var dataSettigs = new DataSettings();
            dataSettigs.DataConnectionString = "name=DefaultConnection";//"data source=VM-SQL2012-01;initial catalog=spartane;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            dataSettigs.DataProvider = "sqlserver";

            builder.Register(x => new EFDataProviderManager(dataSettigs)).As<BaseDataProviderManager>().InstancePerLifetimeScope();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerLifetimeScope();
            builder.Register<IDbContext>(c => new TTObjectContext(dataSettigs.DataConnectionString)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType<DepartamentoService>().As<IDepartamentoService>().InstancePerLifetimeScope();
            builder.RegisterType<EmpleadoService>().As<IEmpleadoService>().InstancePerLifetimeScope();
            builder.RegisterType<ArchivosService>().As<IArchivosService>().InstancePerLifetimeScope();
            builder.RegisterType<PuestoService>().As<IPuestoService>().InstancePerLifetimeScope();

            GlobalConfiguration.Configuration.EnsureInitialized(); 

            //// Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            //// Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //// OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);

            //// Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
