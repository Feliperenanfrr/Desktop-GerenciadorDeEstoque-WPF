using System;
using System.Collections.Generic;
using System.Windows;

namespace CadastroProdutosWPF
{
    public partial class MainWindow : Window
    {
        // Lista de produtos
        private List<Produto> Produtos { get; set; } = new List<Produto>();

        public MainWindow()
        {
            InitializeComponent();
            // Atualiza o DataGrid com a lista de produtos
            dgProdutos.ItemsSource = Produtos;
        }

        // Evento do botão Salvar
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            // Validação dos campos
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                !decimal.TryParse(txtPreco.Text, out decimal preco) ||
                !int.TryParse(txtQuantidade.Text, out int quantidade))
            {
                MessageBox.Show("Preencha todos os campos corretamente.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Cria um novo produto
            var produto = new Produto
            {
                Nome = txtNome.Text,
                Preco = preco,
                QuantidadeEmEstoque = quantidade
            };

            // Adiciona o produto à lista
            Produtos.Add(produto);

            // Atualiza o DataGrid
            dgProdutos.ItemsSource = null; // Força a atualização
            dgProdutos.ItemsSource = Produtos;

            // Limpa os campos
            LimparCampos();
        }

        // Evento do botão Limpar
        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
        }

        // Método para limpar os campos
        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
        }
    }

    // Classe Produto
    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }
}