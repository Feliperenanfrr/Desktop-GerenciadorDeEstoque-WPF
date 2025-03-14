using System.Windows;
using System.Windows.Controls;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            
            // Configurando o DataContext usando o ServiceProvider
            DataContext = App.ServiceProvider.GetRequiredService<DashboardViewModel>();
        }
    }
}