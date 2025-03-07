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

        var mainWindow = ServiceProvider.GetRequiredService<VendaView>(); // Testando outra View
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Registrando o DbContext
        services.AddDbContext<AppDbContext>();

        // Registrando os serviços
        services.AddSingleton<IProdutoService, ProdutoService>();
        services.AddSingleton<IFinanceiroService, FinanceiroService>(); // Adicionei o Service
        services.AddSingleton<IVendaService, VendaService>();


        // Registrando os ViewModels
        services.AddTransient<ProdutoViewModel>();
        services.AddTransient<FinanceiroViewModel>();
        services.AddTransient<VendaViewModel>();

        // Registrando as Views
        services.AddTransient<ProdutoView>();
        services.AddTransient<TransacaoView>();
        services.AddTransient<VendaView>();
    }
}