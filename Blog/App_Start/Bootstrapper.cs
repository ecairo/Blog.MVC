using Autofac;
using Autofac.Integration.Mvc;
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

            // Crea el contenedor Autofac
            IContainer container = builder.Build();

            // Configura la resolución de dependencias para los controladores de MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}