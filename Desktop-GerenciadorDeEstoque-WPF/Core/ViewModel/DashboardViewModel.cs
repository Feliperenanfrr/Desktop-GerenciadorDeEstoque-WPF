using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;
using LiveCharts;
using LiveCharts.Wpf;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel
{
    public class DashboardViewModel
    {
        private readonly FinanceiroService _financeiroService;
        private readonly VendaService _vendaService;
        private readonly ProdutoService _produtoService;

        public SeriesCollection FinanceiroChart { get; set; }
        public SeriesCollection VendasChart { get; set; }
        public SeriesCollection ProdutosChart { get; set; }
        
        public DashboardViewModel(FinanceiroService financeiroService, VendaService vendaService, ProdutoService produtoService)
        {
            _financeiroService = financeiroService;
            _vendaService = vendaService;
            _produtoService = produtoService;
            
            CarregarGraficos();
        }

        private void CarregarGraficos()
        {
            CarregarGraficoFinanceiro();
            CarregarGraficoVendas();
            CarregarGraficoProdutos();
        }

        private void CarregarGraficoFinanceiro()
        {
            var transacoes = _financeiroService.ListarTransacoes();
            var entradas = transacoes.Where(t => !t.Tipo).Sum(t => t.Valor);
            var saidas = transacoes.Where(t => t.Tipo).Sum(t => t.Valor);

            FinanceiroChart = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Entradas",
                    Values = new ChartValues<decimal> { entradas }
                },
                new ColumnSeries
                {
                    Title = "Saídas",
                    Values = new ChartValues<decimal> { saidas }
                }
            };
        }

        private void CarregarGraficoVendas()
        {
            var vendas = _vendaService.ListarVendas();
            var totalVendas = vendas.Sum(v => v.PrecoTotalVenda);
            
            VendasChart = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Vendas",
                    Values = new ChartValues<decimal> { totalVendas }
                }
            };
        }

        private void CarregarGraficoProdutos()
        {
            var produtos = _produtoService.ListarProdutos();
            
            ProdutosChart = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Produtos em Estoque",
                    Values = new ChartValues<int>(produtos.Select(p => p.Quantidade))
                }
            };
        }
    }
}
