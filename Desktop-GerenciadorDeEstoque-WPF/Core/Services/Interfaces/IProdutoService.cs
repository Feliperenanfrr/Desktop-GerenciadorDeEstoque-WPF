using Desktop_GerenciadorDeEstoque_WPF.Core.Model;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;

public interface IProdutoService
{
    
    List<Produto> ListarProdutos();
    void CriarProduto(Produto produto);
    void AtualizarProduto(Produto produto);
    void ExcluirProduto(int id);
    Produto BuscarProdutoPorId(int id);
    Task<List<Produto>> ListarProdutosAsync(); 
    
}