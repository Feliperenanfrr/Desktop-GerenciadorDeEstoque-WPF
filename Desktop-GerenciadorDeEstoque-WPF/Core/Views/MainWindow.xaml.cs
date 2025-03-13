using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;
using System.Windows;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }

    }
}