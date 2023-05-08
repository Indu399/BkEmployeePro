using Autofac;
using Autofac.Integration.Mvc;
using BkEmployeePro.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace BkEmployeePro
{
    public class Bootstrapper
    {
    public static void Run()
        {
            SetAutofacContainer();
            //
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(typeof(EmployeeBLL).Assembly)
            .Where(t => t.Name.EndsWith("BLL"))
            .AsImplementedInterfaces().InstancePerHttpRequest();

            //builder.RegisterAssemblyTypes(typeof(FormAuthService).Assembly)
            //.Where(t => t.Name.EndsWith("Service"))
            //.AsImplementedInterfaces().InstancePerHttpRequest();

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}