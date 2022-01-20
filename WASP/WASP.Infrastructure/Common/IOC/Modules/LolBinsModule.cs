using Autofac;
using WASP.Domain.Entities;
using WASP.Infrastructure.LolBins;
using WASP.Infrastructure.Vulnerabilities.Executions.Mshta;

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
                    componentContext.Resolve<MshtaLolBin>()
                };

            }).As<IEnumerable<LolBin>>();


            base.Load(builder);
        }
    }
}
