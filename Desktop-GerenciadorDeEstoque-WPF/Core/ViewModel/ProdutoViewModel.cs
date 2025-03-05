using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using System.Collections.ObjectModel;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;

public partial class ProdutoViewModel : ObservableObject
{
    private readonly IProdutoService _produtoService;

    [ObservableProperty]
    private ObservableCollection<Produto> _produtos;

    [ObservableProperty]
    private Produto _produtoSelecionado;

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
        var novoProduto = new Produto
        {
            Nome = "Novo Produto",
            Quantidade = 10,
            ValorDeCusto = 50.0m,
            ValorVenda = 100.0m
        };

        _produtoService.CriarProduto(novoProduto);
        _produtos.Add(novoProduto);
    }

    private void EditarProduto()
    {
        if (_produtoSelecionado != null)
        {
            _produtoService.AtualizarProduto(_produtoSelecionado);
        }
    }

    private void ExcluirProduto()
    {
        if (_produtoSelecionado != null)
        {
            _produtoService.ExcluirProduto(_produtoSelecionado.Id);
            _produtos.Remove(_produtoSelecionado);
        }
    }

    private void ListarProdutos()
    {
        Produtos = new ObservableCollection<Produto>(_produtoService.ListarProdutos());
    }

}
