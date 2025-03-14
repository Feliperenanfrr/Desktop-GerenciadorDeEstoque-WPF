using System.Windows;
using System.Windows.Controls;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Views
{
    public partial class ProdutoView : UserControl
    {
        public ProdutoView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<ProdutoViewModel>();
        }

        public ProdutoView(ProdutoViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}