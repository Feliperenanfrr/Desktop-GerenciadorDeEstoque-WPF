using System.Windows;
using System.Windows.Controls;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Views
{
    public partial class ProdutoView : UserControl
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
        
        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            // Encontra a janela principal e redefine o conteúdo para null (ou para outra tela inicial)
            //if (Window.GetWindow(this) is MainWindow mainWindow)
            //{
            //    mainWindow.MainContent.Content = null; // Remove a ProdutoView e volta ao menu
            //}
        }
    }
}