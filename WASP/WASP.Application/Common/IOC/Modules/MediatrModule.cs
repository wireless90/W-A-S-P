using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace WASP.Core.Common.IOC.Modules
{
    public class MediatrModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(typeof(ApplicationModule).Assembly);

            base.Load(builder);
        }
    }
}
