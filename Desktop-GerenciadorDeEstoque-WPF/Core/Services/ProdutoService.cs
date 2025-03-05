using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using Desktop_GerenciadorDeEstoque_WPF.Data;
using Microsoft.EntityFrameworkCore;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services;

public class ProdutoService : IProdutoService
{
    private readonly AppDbContext _context;
    
    // Construtor que recebe DbContext via injeção de dependência
    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public List<Produto> ListarProdutos()
    {
        return _context.Produtos.ToList();
    }

    public void CriarProduto(Produto produto)
    {
        if (produto == null)
            throw new ArgumentNullException(nameof(produto));
        
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    public void AtualizarProduto(Produto produto)
    {
        if (produto == null)
            throw new ArgumentNullException(nameof(produto));
        
        var produtoExistente = _context.Produtos.Find(produto.Id);
        if (produtoExistente == null)
            throw new InvalidOperationException($"Produto {produto.Id} não existente");
        
        produtoExistente.Nome = produto.Nome;
        produtoExistente.ValorDeCusto = produto.ValorDeCusto;
        produtoExistente.Quantidade = produto.Quantidade;
        produtoExistente.ValorDeCusto = produto.ValorDeCusto;
        _context.SaveChanges();
    }

    public void ExcluirProduto(int id)
    {
        var produtoExistente = _context.Produtos.Find(id);
        if (produtoExistente == null)
            throw new InvalidOperationException($"Produto {id} não existente");
        
        _context.Produtos.Remove(produtoExistente);
        _context.SaveChanges();
    }

    public Produto BuscarProdutoPorId(int id)
    {
        var produtoExistente = _context.Produtos.Find(id);
        if (produtoExistente == null)
            throw new InvalidOperationException($"Produto {id} não existente");
        
        return _context.Produtos.Find(id);
    }
}