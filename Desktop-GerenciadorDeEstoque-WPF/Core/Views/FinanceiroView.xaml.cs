using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Views
{
    public partial class TransacaoView : Window
    {
        public TransacaoView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<FinanceiroViewModel>();
        }

        public TransacaoView(FinanceiroViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}