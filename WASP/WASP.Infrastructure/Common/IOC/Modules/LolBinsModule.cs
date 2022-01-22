using Autofac;
using System.Reflection;
using WASP.Domain.Entities;
using WASP.Infrastructure.LolBins;

namespace WASP.Infrastructure.Common.IOC.Modules
{
    public class LolBinsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(context =>
            {
                IComponentContext componentContext = context.Resolve<IComponentContext>();
                
                Assembly executingAssembly = Assembly.GetExecutingAssembly();

                List<LolBin> result = new List<LolBin>();

                executingAssembly
                    .ExportedTypes
                    .Where(t => t.IsClass && t.IsAssignableTo(typeof(LolBin)) && t.GetType() != typeof(LolBin))
                    .ToList()
                    .ForEach(lolbinType => result.Add((LolBin)componentContext.Resolve(lolbinType)));

                return result.AsEnumerable();

            }).As<IEnumerable<LolBin>>();


            base.Load(builder);
        }
    }
}
