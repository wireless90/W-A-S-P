using Autofac;
using WASP.Infrastructure.LolBins;
using WASP.Infrastructure.Vulnerabilities.Executions.Mshta;

namespace WASP.Infrastructure.Common.IOC.Modules
{
    public class MshtaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                return new MshtaLolBin("mshta.exe", "A html application program")
                                    .RegisterVulnerability(new MshtaExecuteJScriptExecutionVulnerability());
            })
            .AsSelf();


            base.Load(builder);
        }
    }
}
