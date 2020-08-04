using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFAdaptiveCards.Pages;

namespace XFAdaptiveCards
{
    public partial class App : Application
    {
        static IContainer _container;
        static readonly ContainerBuilder builder = new ContainerBuilder();
        public App()
        {
            InitializeComponent();

            DependencyResolver.ResolveUsing(type => _container.IsRegistered(type) ? _container.Resolve(type) : null);
            MainPage = new NavigationPage(new MainPage());
        }

        public static void RegisterType<T>() where T : class
        {
            builder.RegisterType<T>();
        }

        public static void RegisterType<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            builder.RegisterType<T>().As<TInterface>();
        }

        public static void RegisterTypeWithParameters<T>(Type param1Type, object param1Value, Type param2Type, string param2Name) where T : class
        {
            builder.RegisterType<T>()
                   .WithParameters(new List<Parameter>()
            {
                new TypedParameter(param1Type, param1Value),
                new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == param2Type && pi.Name == param2Name,
                    (pi, ctx) => ctx.Resolve(param2Type))
            });
        }

        public static void RegisterTypeWithParameters<TInterface, T>(Type param1Type, object param1Value, Type param2Type, string param2Name) where TInterface : class where T : class, TInterface
        {
            builder.RegisterType<T>()
                   .WithParameters(new List<Parameter>()
            {
                new TypedParameter(param1Type, param1Value),
                new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == param2Type && pi.Name == param2Name,
                    (pi, ctx) => ctx.Resolve(param2Type))
            }).As<TInterface>();
        }

        public static void BuildContainer()
        {
            _container = builder.Build();
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
