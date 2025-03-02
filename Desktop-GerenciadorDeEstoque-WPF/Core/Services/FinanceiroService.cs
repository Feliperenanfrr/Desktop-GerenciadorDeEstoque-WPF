using Desktop_GerenciadorDeEstoque_WPF.Core.Model;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services;

public class FinanceiroService
{
    private List<TransacaoFinanceira> _transacoes = new List<TransacaoFinanceira>();

    public void AdicionarTransacao(TransacaoFinanceira transacaoFinanceira)
    {
        _transacoes.Add(transacaoFinanceira);
    }

    public decimal CalcularSaldo()
    {
        return _transacoes.Where(t => t.Tipo == "Entrada").Sum(t => t.Valor) -
               _transacoes.Where(t => t.Tipo == "Saida").Sum(t => t.Valor);
    }
}