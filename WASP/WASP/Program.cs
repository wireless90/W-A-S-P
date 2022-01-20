using Autofac;
using MediatR;
using WASP.Common.IOC;

namespace WASP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IContainer container = ContainerConfig.CreateContainer();
            using(ILifetimeScope scope = container.BeginLifetimeScope())
            {
                IMediator mediator = container.Resolve<IMediator>();

                Application.Run(new MainForm(mediator));
            }
        }
    }
}