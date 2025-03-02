using System.Collections.ObjectModel;
using System.ComponentModel;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;

public class DashboardViewModel : INotifyPropertyChanged
{
    private ObservableCollection<TransacaoFinanceira> _transacoes = new ();
    private FinanceiroService _financeiroService = new FinanceiroService();

    public ObservableCollection<TransacaoFinanceira> Transacoes
    {
        get { return _transacoes; }
        set { _transacoes = value; OnPropertyChanged(nameof(Transacoes)); }
    }
    
    public void AdicionarTransacao(TransacaoFinanceira transacao)
    {
        _financeiroService.AdicionarTransacao(transacao);
        Transacoes.Add(transacao);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}