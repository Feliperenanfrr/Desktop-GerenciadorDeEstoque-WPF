using System.Configuration;
using System.Data;
using System.Windows;
using CadastroProdutosWPF;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;
using Desktop_GerenciadorDeEstoque_WPF.Data;
using Desktop_GerenciadorDeEstoque_WPF.Views;
using Microsoft.Extensions.DependencyInjection;


namespace Desktop_GerenciadorDeEstoque_WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var produtoView = serviceProvider.GetRequiredService<ProdutoView>();
        produtoView.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        
        services.AddSingleton<IProdutoService, ProdutoService>();

        services.AddTransient<MainWindow>();

        services.AddTransient<ProdutoViewModel>();

        services.AddTransient<ProdutoView>();
        
    }
}