using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using System.Windows;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels
{
    public partial class VendaViewModel : ObservableObject
    {
        private readonly IVendaService _vendasService;
        private readonly IProdutoService _produtoService;

        [ObservableProperty]
        private ObservableCollection<Venda> vendas;

        [ObservableProperty]
        private ObservableCollection<Produto> produtosDisponiveis;

        [ObservableProperty]
        private Venda vendaSelecionada;

        [ObservableProperty]
        private Produto produtoSelecionado;

        [ObservableProperty]
        private int quantidade;

        [ObservableProperty]
        private decimal precoTotal;

        [ObservableProperty]
        private DateTime dataVenda = DateTime.Now;

        public VendaViewModel(IVendaService vendasService, IProdutoService produtoService)
        {
            _vendasService = vendasService;
            _produtoService = produtoService;

            Vendas = new ObservableCollection<Venda>(_vendasService.ListarVendas());
            ProdutosDisponiveis = new ObservableCollection<Produto>(_produtoService.ListarProdutos());

            CriarVendaCommand = new RelayCommand(CriarVenda);
            EditarVendaCommand = new RelayCommand(EditarVenda, () => VendaSelecionada != null);
            ExcluirVendaCommand = new RelayCommand(ExcluirVenda, () => VendaSelecionada != null);
        }

        public IRelayCommand CriarVendaCommand { get; }
        public IRelayCommand EditarVendaCommand { get; }
        public IRelayCommand ExcluirVendaCommand { get; }

        private void CriarVenda()
        {
            if (ProdutoSelecionado == null || Quantidade <= 0)
            {
                MessageBox.Show("Selecione um produto e informe a quantidade corretamente!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ProdutoSelecionado.Quantidade < Quantidade)
            {
                MessageBox.Show("Estoque insuficiente para essa venda!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var novaVenda = new Venda
            {
                Produto = ProdutoSelecionado,
                Quantidade = Quantidade,
                DataVenda = DataVenda,
                PrecoTotalVenda = ProdutoSelecionado.ValorVenda * Quantidade
            };

            _vendasService.RegistrarVenda(novaVenda);
            Vendas.Add(novaVenda);

            // Atualiza o estoque
            ProdutoSelecionado.Quantidade -= Quantidade;
            _produtoService.AtualizarProduto(ProdutoSelecionado);

            // Atualiza a lista de produtos
            ProdutosDisponiveis = new ObservableCollection<Produto>(_produtoService.ListarProdutos());

            LimparCampos();
        }

        private void EditarVenda()
        {
            if (VendaSelecionada != null)
            {
                VendaSelecionada.Produto = ProdutoSelecionado;
                VendaSelecionada.Quantidade = Quantidade;
                VendaSelecionada.DataVenda = DataVenda;
                VendaSelecionada.PrecoTotalVenda = ProdutoSelecionado.ValorVenda * Quantidade;

                _vendasService.EditarVenda(VendaSelecionada);

                // Atualizar a lista de vendas
                Vendas = new ObservableCollection<Venda>(_vendasService.ListarVendas());
            }
        }

        private void ExcluirVenda()
        {
            if (VendaSelecionada != null)
            {
                _vendasService.ExcluirVenda(VendaSelecionada.Id);
                Vendas.Remove(VendaSelecionada);
                VendaSelecionada = null;
            }
        }

        private void LimparCampos()
        {
            ProdutoSelecionado = null;
            Quantidade = 0;
            DataVenda = DateTime.Now;
        }

        partial void OnVendaSelecionadaChanged(Venda value)
        {
            EditarVendaCommand.NotifyCanExecuteChanged();
            ExcluirVendaCommand.NotifyCanExecuteChanged();

            if (value != null)
            {
                ProdutoSelecionado = value.Produto;
                Quantidade = value.Quantidade;
                DataVenda = value.DataVenda;
            }
            else
            {
                LimparCampos();
            }
        }
    }
}
