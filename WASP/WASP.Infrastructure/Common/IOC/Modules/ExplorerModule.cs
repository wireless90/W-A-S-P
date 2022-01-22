using Autofac;
using WASP.Infrastructure.LolBins;
using WASP.Infrastructure.Vulnerabilities.Executions.Explorer;

namespace WASP.Infrastructure.Common.IOC.Modules
{
    public class ExplorerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                return (ExplorerLolBin)new ExplorerLolBin("explorer.exe", "A program manager process that provides the graphical interface you use to interact with most of Windows.")
                                    .RegisterVulnerability(new ExplorerExecuteCalcExecutionVulnerability());
            })
            .AsSelf();


            base.Load(builder);
        }
    }
}
