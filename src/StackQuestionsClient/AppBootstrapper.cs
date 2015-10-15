using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using SimpleInjector;
using System.Reflection;
using StackQuestionsClient.ViewModels;
using StackQuestionsClient.utilities;

namespace StackQuestionsClient
{
    internal class AppBootstrapper : BootstrapperBase
    {
        public static readonly Container ContainerInstance = new Container();

        public AppBootstrapper()
        {
            LogManager.GetLog = type => new DebugLogger(type);
            Initialize();
        }

        protected override void Configure()
        {
            ContainerInstance.Register<IWindowManager, WindowManager>();
            ContainerInstance.RegisterSingleton<IEventAggregator, EventAggregator>();

            ContainerInstance.Register<MainWindowViewModel, MainWindowViewModel>();

            ContainerInstance.Verify();
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            // This line throwing is exception when running the application
            // Error: 
            // ---> An exception of type 'SimpleInjector.ActivationException' occurred in SimpleInjector.dll
            // ---> Additional information: No registration for type IEnumerable<MainWindowView> could be found. 
            // ---> No registration for type IEnumerable<MainWindowView> could be found. 
            // return ContainerInstance.GetAllInstances(service);

            IServiceProvider provider = ContainerInstance;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(service);
            var services = (IEnumerable<object>)provider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }

        protected override object GetInstance(System.Type service, string key)
        {
            return ContainerInstance.GetInstance(service);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] {
                    Assembly.GetExecutingAssembly()
                };
        }

        protected override void BuildUp(object instance)
        {
            var registration = ContainerInstance.GetRegistration(instance.GetType(), true);
            registration.Registration.InitializeInstance(instance);
        }
    }
}
