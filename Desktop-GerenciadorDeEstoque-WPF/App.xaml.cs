using System;
using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;
using Desktop_GerenciadorDeEstoque_WPF.Data;
using Desktop_GerenciadorDeEstoque_WPF.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            
            ServiceProvider = serviceCollection.BuildServiceProvider();

            // Define o DashboardView como a janela principal para teste
            var mainWindow = ServiceProvider.GetRequiredService<DashboardView>(); 
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Registrando o DbContext
            services.AddDbContext<AppDbContext>();

            // Registrando os serviços
            services.AddSingleton<IProdutoService, ProdutoService>();
            services.AddSingleton<IFinanceiroService, FinanceiroService>();
            services.AddSingleton<IVendaService, VendaService>();
            services.AddSingleton<IMaterialService, MaterialService>();
            services.AddSingleton<IDashboardService, DashboardService>(); // 🔹 Adicionado para corrigir erro

            // Registrando os ViewModels
            services.AddTransient<ProdutoViewModel>();
            services.AddTransient<FinanceiroViewModel>();
            services.AddTransient<VendaViewModel>();
            services.AddTransient<MaterialViewModel>();
            services.AddTransient<DashboardViewModel>();

            // Registrando as Views
            services.AddTransient<ProdutoView>();
            services.AddTransient<TransacaoView>();
            services.AddTransient<VendaView>();
            services.AddTransient<MaterialView>();
            services.AddTransient<DashboardView>();
        }
    }
}
