using Autofac;
using WASP.Application.Common.IOC.Modules;

namespace WASP.Application.Common.IOC
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
