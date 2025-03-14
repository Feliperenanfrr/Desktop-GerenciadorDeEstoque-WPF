using System.Windows;
using System.Windows.Controls;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Views
{
    public partial class VendaView : UserControl
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
