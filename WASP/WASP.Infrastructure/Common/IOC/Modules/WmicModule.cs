using Autofac;
using WASP.Infrastructure.LolBins;
using WASP.Infrastructure.Vulnerabilities.Executions.ForFiles;

namespace WASP.Infrastructure.Common.IOC.Modules
{
    public class WmicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                return (WmicLolBin)new WmicLolBin()
                                            .RegisterVulnerability(new WmicExecuteCalcExecutionVulnerability());

            })
            .AsSelf();

            base.Load(builder);
        }
    }
}
