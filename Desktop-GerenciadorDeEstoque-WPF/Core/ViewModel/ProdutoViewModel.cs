using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;

public partial class ProdutoViewModel : ObservableObject
{
    private readonly IProdutoService _produtoService;

    [ObservableProperty]
    private ObservableCollection<Produto> _produtos;

    [ObservableProperty]
    private Produto _produtoSelecionado;

    [ObservableProperty]
    private string _nome;

    [ObservableProperty]
    private int _quantidade;

    [ObservableProperty]
    private decimal _valorDeCusto;

    [ObservableProperty]
    private decimal _valorVenda;

    public ProdutoViewModel(IProdutoService produtoService)
    {
        _produtoService = produtoService;

        _produtos = new ObservableCollection<Produto>(_produtoService.ListarProdutos());

        CriarProdutoCommand = new RelayCommand(CriarProduto);
        EditarProdutoCommand = new RelayCommand(EditarProduto, () => _produtoSelecionado != null);
        ExcluirProdutoCommand = new RelayCommand(ExcluirProduto, () => _produtoSelecionado != null);
        ListarProdutosCommand = new RelayCommand(ListarProdutos);
    }

    public IRelayCommand CriarProdutoCommand { get; }
    public IRelayCommand EditarProdutoCommand { get; }
    public IRelayCommand ExcluirProdutoCommand { get; }
    public IRelayCommand ListarProdutosCommand { get; }

    private void CriarProduto()
    {
        if (string.IsNullOrWhiteSpace(Nome) || Quantidade <= 0 || ValorDeCusto <= 0 || ValorVenda <= 0)
        {
            MessageBox.Show("Preencha todos os campos corretamente!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var novoProduto = new Produto
        {
            Nome = Nome,
            Quantidade = Quantidade,
            ValorDeCusto = ValorDeCusto,
            ValorVenda = ValorVenda
        };

        _produtoService.CriarProduto(novoProduto);
        _produtos.Add(novoProduto);

        // Limpar os campos após criar
        Nome = string.Empty;
        Quantidade = 0;
        ValorDeCusto = 0;
        ValorVenda = 0;
    }

    private void EditarProduto()
    {
        if (_produtoSelecionado != null)
        {
            _produtoSelecionado.Nome = Nome;
            _produtoSelecionado.Quantidade = Quantidade;
            _produtoSelecionado.ValorDeCusto = ValorDeCusto;
            _produtoSelecionado.ValorVenda = ValorVenda;

            _produtoService.AtualizarProduto(_produtoSelecionado);
            ListarProdutos();
        }
    }

    private void ExcluirProduto()
    {
        if (_produtoSelecionado != null)
        {
            _produtoService.ExcluirProduto(_produtoSelecionado.Id);
            _produtos.Remove(_produtoSelecionado);
            ProdutoSelecionado = null;
        }
    }

    private void ListarProdutos()
    {
        Produtos = new ObservableCollection<Produto>(_produtoService.ListarProdutos());
    }

    partial void OnProdutoSelecionadoChanged(Produto value)
    {
        EditarProdutoCommand.NotifyCanExecuteChanged();
        ExcluirProdutoCommand.NotifyCanExecuteChanged();

        if (value != null)
        {
            Nome = value.Nome;
            Quantidade = value.Quantidade;
            ValorDeCusto = value.ValorDeCusto;
            ValorVenda = value.ValorVenda;
        }
        else
        {
            // Limpar campos se nenhum produto estiver selecionado
            Nome = string.Empty;
            Quantidade = 0;
            ValorDeCusto = 0;
            ValorVenda = 0;
        }
    }
}
