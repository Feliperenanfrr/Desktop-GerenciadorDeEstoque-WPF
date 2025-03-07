using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Views
{
    public partial class ProdutoView : Window
    {
        public ProdutoView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<ProdutoViewModel>(); // Instância padrão do ViewModel
        }

        public ProdutoView(ProdutoViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
