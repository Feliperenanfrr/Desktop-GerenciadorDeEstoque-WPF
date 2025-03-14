using System.Windows;
using System.Windows.Controls;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Views
{
    public partial class FinanceiroView : UserControl
    {
        public FinanceiroView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<FinanceiroViewModel>();
        }

        public FinanceiroView(FinanceiroViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}