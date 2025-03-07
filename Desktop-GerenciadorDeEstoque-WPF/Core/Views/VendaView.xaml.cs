using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Views
{
    public partial class VendaView : Window
    {
        public VendaView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<VendaViewModel>();
        }

        public VendaView(VendaViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
