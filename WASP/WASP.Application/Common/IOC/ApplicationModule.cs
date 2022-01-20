using Autofac;
using WASP.Core.Common.IOC.Modules;

namespace WASP.Core.Common.IOC
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<MediatrModule>();

            base.Load(builder);
        }
    }
}
