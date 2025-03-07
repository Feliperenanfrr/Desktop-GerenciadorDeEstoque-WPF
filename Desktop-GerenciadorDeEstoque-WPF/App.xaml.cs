using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;
using Desktop_GerenciadorDeEstoque_WPF.Data;
using Desktop_GerenciadorDeEstoque_WPF.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        
        ServiceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<TransacaoView>(); // Ou MainWindow se for a principal
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Registrando o DbContext
        services.AddDbContext<AppDbContext>();

        // Registrando os serviços
        services.AddSingleton<IProdutoService, ProdutoService>();
        services.AddSingleton<IFinanceiroService, FinanceiroService>(); // Adicionei o Service

        // Registrando os ViewModels
        services.AddTransient<ProdutoViewModel>();
        services.AddTransient<TransacoesViewModel>(); // Adicionei o ViewModel

        // Registrando as Views
        services.AddTransient<ProdutoView>();
        services.AddTransient<TransacaoView>(); // Adicionei a View
    }
}