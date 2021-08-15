using GuessANumber.Engine;
using GuessANumber.Engine.Interfaces;
using GuessANumber.Infrastructure;
using GuessANumber.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GuessANumber.ConsoleClient
{
    public class Startup
    {
        private static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider?.GetService<IEngine>()?.Start();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IWriter, ConsoleWriter>();
            serviceCollection.AddSingleton<IReader, ConsoleReader>();
            serviceCollection.AddSingleton<IGuard, Guard>();
            serviceCollection.AddScoped<IRandomGenerator, RandomGenerator>();
            serviceCollection.AddScoped<IManager, GuessManager>();
            serviceCollection.AddSingleton<IEngine, GuessEngine>();
        }
    }
}