using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Views
{
    public partial class MaterialView : Window
    {
        public MaterialView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<MaterialViewModel>();
        }

        public MaterialView(MaterialViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}