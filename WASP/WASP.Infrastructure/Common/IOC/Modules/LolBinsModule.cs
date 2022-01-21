using Autofac;
using WASP.Domain.Entities;
using WASP.Infrastructure.LolBins;

namespace WASP.Infrastructure.Common.IOC.Modules
{
    public class LolBinsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(context =>
            {
                IComponentContext componentContext = context.Resolve<IComponentContext>();

                return new List<LolBin>()
                {
                    componentContext.Resolve<MshtaLolBin>(),
                    componentContext.Resolve<ExplorerLolBin>()
                };

            }).As<IEnumerable<LolBin>>();


            base.Load(builder);
        }
    }
}
