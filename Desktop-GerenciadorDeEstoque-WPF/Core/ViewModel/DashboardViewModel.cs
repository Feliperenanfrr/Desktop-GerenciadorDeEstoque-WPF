using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using LiveCharts;
using System.Threading.Tasks;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        private readonly IDashboardService _dashboardService;

        [ObservableProperty]
        private SeriesCollection _financeiroChart;

        [ObservableProperty]
        private SeriesCollection _vendasChart;

        [ObservableProperty]
        private SeriesCollection _produtosChart;

        public DashboardViewModel(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
            AtualizarGraficosCommand = new AsyncRelayCommand(AtualizarGraficos);
            _ = AtualizarGraficos(); // Carregar os gráficos ao iniciar
        }

        public IAsyncRelayCommand AtualizarGraficosCommand { get; }

        private async Task AtualizarGraficos()
        {
            FinanceiroChart = await _dashboardService.ObterGraficoFinanceiroAsync();
            VendasChart = await _dashboardService.ObterGraficoVendasAsync();
            ProdutosChart = await _dashboardService.ObterGraficoProdutosAsync();
        }
    }
}