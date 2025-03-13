using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Views
{
    public partial class DashboardView : Window
    {
        public DashboardView()
        {
            InitializeComponent();
            
            // Configurando o DataContext usando o ServiceProvider
            DataContext = App.ServiceProvider.GetRequiredService<DashboardViewModel>();
        }
    }
}