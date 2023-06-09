﻿using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Blog.Data;
using Blog.Data.Infrastructure;
using Blog.Data.Repositories;
using Blog.Entities;
using Blog.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Blog.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            // Registra los controladores
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Registra las dependencias
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>().InstancePerRequest();

            builder.RegisterType<AuthorService>().As<IAuthorService>().InstancePerRequest();

            // Registrando AutoMapper
            builder.Register<IConfigurationProvider>(ctx => new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly())));
            builder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve)).InstancePerDependency();

            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new BlogEntities())))
                .As<UserManager<ApplicationUser>>().InstancePerLifetimeScope();

            // Crea el contenedor Autofac
            IContainer container = builder.Build();

            // Configura la resolución de dependencias para los controladores de MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}