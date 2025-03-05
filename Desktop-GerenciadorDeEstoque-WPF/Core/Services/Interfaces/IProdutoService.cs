using CadastroProdutosWPF;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;

public interface IProdutoService
{
    void CriarProduto(Produto produto);
    void AtualizarProduto(Produto produto);
    void ExcluirProduto(int id);
    List<Produto> ListarProdutos();
    Produto BuscarProdutoPorId(int id);
    
}