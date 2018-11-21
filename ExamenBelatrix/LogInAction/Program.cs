using Autofac;
using Logger.Core;
using Logger.CustomLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInAction
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CustomLog>().As<ILog>();
            builder.RegisterType<CustomLoggerFactory>().As<ILogFactory>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var log = scope.Resolve<ILog>();
                log.LogError("This is an error to console.", LogDestination.Console);
                log.LogError("This is an error to text file.", LogDestination.TextFile);
                log.LogError("This is an error to database.", LogDestination.Database);

                log.LogMessage("This is a message to console.", LogDestination.Console);
                log.LogMessage("This is a message to text file.", LogDestination.TextFile);
                log.LogMessage("This is a message to database.", LogDestination.Database);

                log.LogWarning("This is a warning to console.", LogDestination.Console);
                log.LogWarning("This is a warning to text file.", LogDestination.TextFile);
                log.LogWarning("This is a warning to database.", LogDestination.Database);

                log.LogError("This is an error to multiple destinations.", LogDestination.Console, LogDestination.Database, LogDestination.TextFile);
                log.LogMessage("This is a message to multiple destinations.", LogDestination.Console, LogDestination.Database, LogDestination.TextFile);
                log.LogWarning("This is a warning to multiple destinations.", LogDestination.Console, LogDestination.Database, LogDestination.TextFile);
            }

            Console.ReadKey();
        }
    }
}
