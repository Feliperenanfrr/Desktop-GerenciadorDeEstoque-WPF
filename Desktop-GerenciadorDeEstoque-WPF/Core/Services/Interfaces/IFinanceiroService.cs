using Desktop_GerenciadorDeEstoque_WPF.Core.Model;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;

public interface IFinanceiroService
{
    List<Financeiro> ListarTransacoes();
    void CriarTransacao(Financeiro transacao);
    void AtualizarTransacao(Financeiro transacao);
    void ExcluirTransacao(int id);
    Financeiro BuscarTransacaoPorId(int id);
    List<Financeiro> FiltrarTransacoesPorData(DateTime dataInicial, DateTime dataFinal);
    decimal CalcularSaldoAtual();
    Task<List<Financeiro>> ListarTransacoesAsync();
}