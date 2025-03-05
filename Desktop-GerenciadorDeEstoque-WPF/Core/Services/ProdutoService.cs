using CadastroProdutosWPF;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services;

public class ProdutoService
{
    public bool VerificarEstoque(Produto produto, int quantidade)
    {
        return produto.QuantidadeEmEstoque >= quantidade;
    }

    public void ReduzirEstoque(Produto produto, int quantidade)
    {
        if (!VerificarEstoque(produto, quantidade))
            throw new InvalidOperationException("Estoque insuficiente");
        
        produto.QuantidadeEmEstoque -= quantidade;
    }
}