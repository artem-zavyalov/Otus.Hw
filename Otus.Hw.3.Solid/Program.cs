using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Otus.Hw._3.Solid.Models.Options;
using Otus.Hw._3.Solid.Service;
using Otus.Hw._3.Solid.Service.GameManager;
using Otus.Hw._3.Solid.Service.Games;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json", optional: false)
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);

var serviceProvider = serviceCollection.BuildServiceProvider();

serviceProvider.GetService<Game>()?.Start();

static void ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration)
{
    serviceCollection.AddOptions<GuessGameSettings>().Bind(configuration.GetSection(GuessGameSettings.ConfigKey));

    serviceCollection.AddOptions<GuessIntegerSettings>().Bind(configuration.GetSection(GuessIntegerSettings.ConfigKey));

    serviceCollection.AddTransient<Game>();
    serviceCollection.AddTransient<IGameManager, GameManager>();
    serviceCollection.AddSingleton<GameFactory>();
}