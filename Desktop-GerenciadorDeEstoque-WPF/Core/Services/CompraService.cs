using CadastroProdutosWPF;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services;

public class CompraService
{
    public void RegistrarCompra(Produto produto, int quantidade)
    {
        if (quantidade <= 0) throw new ArgumentException("Quantidade deve ser maior que zero");
        
        produto.QuantidadeEmEstoque += quantidade;
    }
    
}