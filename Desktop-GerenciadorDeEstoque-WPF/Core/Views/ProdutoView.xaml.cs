using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;

namespace Desktop_GerenciadorDeEstoque_WPF.Views
{
    public partial class ProdutoView : Window
    {
        public ProdutoView(ProdutoViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
