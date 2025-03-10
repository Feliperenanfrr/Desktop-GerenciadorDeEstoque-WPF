using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Views;

namespace Desktop_GerenciadorDeEstoque_WPF.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnProdutos_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProdutoView(); // Carregar ProdutoView no ContentControl
        }
    }
}