using Autofac;
using WASP.Core.Common.IOC;
using WASP.Infrastructure.Common.IOC;

namespace WASP.Common.IOC
{
    public static class ContainerConfig
    {
        public static IContainer CreateContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder
                .RegisterModule<ApplicationModule>()
                .RegisterModule<InfrastructureModule>()
                .RegisterModule<FormModule>();

            IContainer container = builder.Build();

            return container;
        }
    }
}
