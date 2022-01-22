using Autofac;
using WASP.Infrastructure.LolBins;
using WASP.Infrastructure.Vulnerabilities.Executions.Wlrmdr;

namespace WASP.Infrastructure.Common.IOC.Modules
{
    public class WlrmdrModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                return (WlrmdrLolBin)new WlrmdrLolBin()
                                            .RegisterVulnerability(new WlrmdrExecuteCalcExecutionVulnerability());

            })
            .AsSelf();

            base.Load(builder);
        }
    }
}
