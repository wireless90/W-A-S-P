using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace WASP.Application.Common.IOC.Modules
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
