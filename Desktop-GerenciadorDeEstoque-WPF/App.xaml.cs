using System.Configuration;
using System.Data;
using System.Windows;
using CadastroProdutosWPF;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using Desktop_GerenciadorDeEstoque_WPF.Data;
using Microsoft.Extensions.DependencyInjection;


namespace Desktop_GerenciadorDeEstoque_WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();

        services.AddScoped<IProdutoService, ProdutoService>();

        services.AddTransient<MainWindow>();
    }
}