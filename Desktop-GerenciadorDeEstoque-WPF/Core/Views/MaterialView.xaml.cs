using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Views
{
    public partial class MaterialView : Window
    {
        public MaterialView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<MaterialViewModel>(); // Instância padrão do ViewModel
        }

        public MaterialView(MaterialViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}