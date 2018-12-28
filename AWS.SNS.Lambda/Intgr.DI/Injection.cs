using Intgr.Interfaces.Functions;
using Intgr.Interfaces.Provider;
using Intgr.Interfaces.Providers;
using Intgr.Worker.Functions;
using Intgr.Worker.Providers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Intgr.DI
{
    public class Injection
    {
        private static IServiceProvider serviceProvider { get; set; }
        public static IServiceProvider DIServiceProvider { get { return serviceProvider; } }

        public Injection()
        {
            Inject();
        }

        private void Inject() {

            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<ISimpleNotificationServiceProvider, SimpleNotificationServiceProvider>();
            services.AddSingleton<IFuncMessageSender, FuncMessageSender>();

            services.AddSingleton<IPinPointServiceProvider, PinPointServiceProvider>();
            services.AddSingleton<IFuncPinPointSender, FuncPinPointSender>();

            serviceProvider = services.BuildServiceProvider();
        }
    }
}
