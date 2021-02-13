using System;
using Topshelf;

namespace DemoWindowServiceScheduler
{
    class Program
    {
        static void Main(string[] args)
        {

            var hostFactory = HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.SetServiceName("DemoWindowService");
                hostConfigurator.SetDisplayName("DemoWindowService");
                hostConfigurator.SetDescription("Service for testing.");

                hostConfigurator.RunAsLocalSystem();

                hostConfigurator.Service<DemoService>(serviceConfigurator =>
                {
                    serviceConfigurator.ConstructUsing(() => new DemoService());

                    serviceConfigurator.WhenStarted(service => service.Start());
                    serviceConfigurator.WhenStopped(service => service.Stop());
                });
            });

            Environment.ExitCode = (int)Convert.ChangeType(hostFactory, hostFactory.GetTypeCode());
        }
    }
}
