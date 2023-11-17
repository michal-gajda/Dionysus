namespace Dionysus.Client.WinUI;

using CommunityToolkit.Mvvm.DependencyInjection;
using Dionysus.Client.Application;
using Dionysus.Client.Infrastructure;
using Dionysus.Client.WinUI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MvvmDialogs;
using MvvmDialogs.DialogTypeLocators;

public partial class App : System.Windows.Application
{
    protected override void OnStartup(System.Windows.StartupEventArgs e)
    {
        base.OnStartup(e);

        IServiceCollection services = new ServiceCollection();

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables()
            .Build();

        services.AddSingleton(configuration);

        services.AddLogging(configure => configure.AddConsole());

        services.AddApplication();
        services.AddInfrastructure(configuration);

        services.AddSingleton<IDialogService, DialogService>();

        services.AddTransient<ShellViewModel>();
        services.AddTransient<ProductCatalogViewModel>();
        services.AddSingleton<IDialogTypeLocator, DialogTypeLocator>();

        IServiceProvider provider = services.BuildServiceProvider();

        Ioc.Default.ConfigureServices(provider);
    }
}
