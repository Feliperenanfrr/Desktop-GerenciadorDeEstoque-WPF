using Desktop_GerenciadorDeEstoque_WPF.Core.Model;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;

public interface IFinanceiroService
{
    List<TransacaoFinanceira> ListarTransacoes();
    void CriarTransacao(TransacaoFinanceira transacao);
    void AtualizarTransacao(TransacaoFinanceira transacao);
    void ExcluirTransacao(int id);
    TransacaoFinanceira BuscarTransacaoPorId(int id);
    List<TransacaoFinanceira> FiltrarTransacoesPorData(DateTime dataInicial, DateTime dataFinal);
    decimal CalcularSaldoAtual();
}