using M5H1;
using M5H1.Config;
using M5H1.Services;
using M5H1.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class Program
{
    private static async Task Main(string[] args)
    {
        void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));
            serviceCollection
                .AddLogging(configure => configure.AddConsole())
                .AddHttpClient()
                .AddTransient<IInternalHttpClientService, InternalHttpClientService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IResourceService, ResourceService>()
                .AddTransient<IRegisterService, RegisterService>()
                .AddTransient<ILoginService, LoginService>()
                .AddTransient<App>();
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();
        await app!.Start();
    }
}