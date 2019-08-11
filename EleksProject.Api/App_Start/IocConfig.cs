using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using EleksProject.Business;
using EleksProject.Core.AutoMapperProfiles;
using EleksProject.Core.Interfaces.DbContext;
using EleksProject.Core.Interfaces.Repositories;
using EleksProject.Core.Interfaces.UnitOfWork;
using EleksProject.Data.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EleksProject.Api.App_Start
{
    public class IocConfig
    {
        public static IContainer RegisterDependencyResolver()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            IocConfig.RegisterBusinessObjects(ref builder);
            IocConfig.RegisterMapper(ref builder, typeof(WebApiApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;
        }

        private static void RegisterBusinessObjects(ref ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(RepositoryBase<>).Assembly)
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepositoryBase<>))
                    || typeof(IDataContext).IsAssignableFrom(t)
                    || (typeof(IUnitOfWork).IsAssignableFrom(t) && !t.IsAbstract))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ManagerBase).Assembly)
               .Where(t => t.Name.EndsWith("Manager"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();
        }

        private static void RegisterMapper(ref ContainerBuilder builder, Assembly assembly)
        {
            var profiles = assembly
                            .GetTypes()
                            .Where(typeof(Profile).IsAssignableFrom);

            var coreProfiles = typeof(CustomerProfile).Assembly
                            .GetTypes()
                            .Where(typeof(Profile).IsAssignableFrom);

            var businessProfiles = typeof(ManagerBase).Assembly
                            .GetTypes()
                            .Where(typeof(Profile).IsAssignableFrom);

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(profiles);
                cfg.AddMaps(coreProfiles);
                cfg.AddMaps(businessProfiles);
            }))
            .AsImplementedInterfaces()
            .SingleInstance();

            builder.RegisterType<Mapper>()
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}