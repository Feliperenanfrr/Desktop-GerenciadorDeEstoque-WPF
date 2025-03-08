using LiveCharts;
using System.Threading.Tasks;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<SeriesCollection> ObterGraficoFinanceiroAsync();
        Task<SeriesCollection> ObterGraficoVendasAsync();
        Task<SeriesCollection> ObterGraficoProdutosAsync();
    }
}