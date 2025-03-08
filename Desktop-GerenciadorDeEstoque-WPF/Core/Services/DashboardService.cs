using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using LiveCharts;
using LiveCharts.Wpf;
using System.Linq;
using System.Threading.Tasks;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IFinanceiroService _financeiroService;
        private readonly IVendaService _vendaService;
        private readonly IProdutoService _produtoService;

        public DashboardService(IFinanceiroService financeiroService, IVendaService vendaService, IProdutoService produtoService)
        {
            _financeiroService = financeiroService;
            _vendaService = vendaService;
            _produtoService = produtoService;
        }

        public async Task<SeriesCollection> ObterGraficoFinanceiroAsync()
        {
            var transacoes = await _financeiroService.ListarTransacoesAsync();
            var entradas = transacoes.Where(t => !t.Tipo).Sum(t => t.Valor);
            var saidas = transacoes.Where(t => t.Tipo).Sum(t => t.Valor);

            return new SeriesCollection
            {
                new ColumnSeries { Title = "Entradas", Values = new ChartValues<decimal> { entradas } },
                new ColumnSeries { Title = "Saídas", Values = new ChartValues<decimal> { saidas } }
            };
        }

        public async Task<SeriesCollection> ObterGraficoVendasAsync()
        {
            var vendas = await _vendaService.ListarVendasAsync();
            var totalVendas = vendas.Sum(v => v.PrecoTotalVenda);

            return new SeriesCollection
            {
                new ColumnSeries { Title = "Vendas", Values = new ChartValues<decimal> { totalVendas } }
            };
        }

        public async Task<SeriesCollection> ObterGraficoProdutosAsync()
        {
            var produtos = await _produtoService.ListarProdutosAsync();

            return new SeriesCollection
            {
                new ColumnSeries { Title = "Produtos em Estoque", Values = new ChartValues<int>(produtos.Select(p => p.Quantidade)) }
            };
        }
    }
}
