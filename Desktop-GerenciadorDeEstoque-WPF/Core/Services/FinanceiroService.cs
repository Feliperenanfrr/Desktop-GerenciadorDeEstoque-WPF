using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using Desktop_GerenciadorDeEstoque_WPF.Data;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services;

public class FinanceiroService : IFinanceiroService
{
    private readonly AppDbContext _context;

    public FinanceiroService(AppDbContext context)
    {
        _context = context;
    }

    public List<TransacaoFinanceira> ListarTransacoes()
    {
        return _context.TransacoesFinanceiras.ToList();
    }

    public void CriarTransacao(TransacaoFinanceira transacao)
    {
        if (transacao == null)
            throw new ArgumentNullException(nameof(transacao));

        _context.TransacoesFinanceiras.Add(transacao);
        _context.SaveChanges();
    }

    public void AtualizarTransacao(TransacaoFinanceira transacao)
    {
        if (transacao == null)
            throw new ArgumentNullException(nameof(transacao));

        var transacaoExistente = _context.TransacoesFinanceiras.Find(transacao.Id);
        if (transacaoExistente == null)
            throw new InvalidOperationException($"Transação {transacao.Id} não existente");

        transacaoExistente.Descricao = transacao.Descricao;
        transacaoExistente.Tipo = transacao.Tipo;
        transacaoExistente.Data = transacao.Data;
        transacaoExistente.Valor = transacao.Valor;

        _context.SaveChanges();
    }

    public void ExcluirTransacao(int id)
    {
        var transacaoExistente = _context.TransacoesFinanceiras.Find(id);
        if (transacaoExistente == null)
            throw new InvalidOperationException($"Transação {id} não existente");

        _context.TransacoesFinanceiras.Remove(transacaoExistente);
        _context.SaveChanges();
    }

    public TransacaoFinanceira BuscarTransacaoPorId(int id)
    {
        var transacaoExistente = _context.TransacoesFinanceiras.Find(id);
        if (transacaoExistente == null)
            throw new InvalidOperationException($"Transação {id} não existente");

        return transacaoExistente;
    }

    public List<TransacaoFinanceira> FiltrarTransacoesPorData(DateTime inicio, DateTime fim)
    {
        return _context.TransacoesFinanceiras
            .Where(t => t.Data >= inicio && t.Data <= fim)
            .ToList();
    }

    public decimal CalcularSaldoAtual()
    {
        var entradas = _context.TransacoesFinanceiras
            .Where(t => t.Tipo == false) // false para "Entrada"
            .Sum(t => t.Valor);

        var saidas = _context.TransacoesFinanceiras
            .Where(t => t.Tipo == true) // true para "Saída"
            .Sum(t => t.Valor);

        return entradas - saidas;
    }
}
