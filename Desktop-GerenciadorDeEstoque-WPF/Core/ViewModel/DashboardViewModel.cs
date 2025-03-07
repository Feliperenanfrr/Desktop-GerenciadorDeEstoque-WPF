using System.Collections.ObjectModel;
using System.ComponentModel;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services;
using Desktop_GerenciadorDeEstoque_WPF.Data;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;

public class DashboardViewModel : INotifyPropertyChanged
{
    static AppDbContext  _context;
    private ObservableCollection<Financeiro> _transacoes = new ();
    private FinanceiroService _financeiroService = new FinanceiroService(_context);

    public ObservableCollection<Financeiro> Transacoes
    {
        get { return _transacoes; }
        set { _transacoes = value; OnPropertyChanged(nameof(Transacoes)); }
    }
    
    public void AdicionarTransacao(Financeiro transacao)
    {
        _financeiroService.CriarTransacao(transacao);
        Transacoes.Add(transacao);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}