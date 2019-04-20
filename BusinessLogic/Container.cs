using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using BusinessLogic;
using BusinessLogic.Service.Interfaces;

namespace BusinessLogic
{
    //
    public static class Container
    {
        private static IContainer _container;

        public static IMathService mathService { get { return _container.Resolve<IMathService>(); } }

        public static void Initialize()
        {
            if (_container == null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<MathService>().As<IMathService>().SingleInstance();
                _container = builder.Build();
            }
        }
    }
}