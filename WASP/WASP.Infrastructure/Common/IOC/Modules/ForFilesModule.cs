using Autofac;
using WASP.Infrastructure.LolBins;
using WASP.Infrastructure.Vulnerabilities.Executions.ForFiles;

namespace WASP.Infrastructure.Common.IOC.Modules
{
    public class ForFilesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                return (ForFilesLolBin) new ForFilesLolBin("forfiles.exe", "A program that selects and executes a command on a file or set of files. This command is useful for batch processing.")
                                            .RegisterVulnerability(new ForFilesExecuteCalcExecutionVulnerability());
                                    
            })
            .AsSelf();

            base.Load(builder);
        }
    }
}
