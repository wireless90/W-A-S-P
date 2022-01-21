using Autofac;
using WASP.Infrastructure.Common.IOC.Modules;

namespace WASP.Infrastructure.Common.IOC
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterModule<MshtaModule>()
                .RegisterModule<ExplorerModule>()
                .RegisterModule<LolBinsModule>();

            base.Load(builder);
        }
    }
}
