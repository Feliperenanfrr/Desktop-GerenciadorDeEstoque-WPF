using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;

public partial class TransacoesViewModel : ObservableObject
{
    private readonly IFinanceiroService _financeiroService;

    [ObservableProperty]
    private ObservableCollection<TransacaoFinanceira> _transacoes;

    [ObservableProperty]
    private TransacaoFinanceira _transacaoSelecionada;

    [ObservableProperty]
    private string _descricao;

    [ObservableProperty]
    private bool? _tipo; // false = Entrada, true = Saída

    [ObservableProperty]
    private DateTime _data = DateTime.Now;

    [ObservableProperty]
    private decimal _valor;

    [ObservableProperty]
    private decimal _saldoAtual;

    // Adicionando a coleção de Tipos de Transação
    [ObservableProperty]
    private ObservableCollection<string> _tiposTransacao = new ObservableCollection<string> { "Entrada", "Saída" };

    public TransacoesViewModel(IFinanceiroService financeiroService)
    {
        _financeiroService = financeiroService;

        _transacoes = new ObservableCollection<TransacaoFinanceira>(_financeiroService.ListarTransacoes());
        _saldoAtual = _financeiroService.CalcularSaldoAtual();

        CriarTransacaoCommand = new RelayCommand(CriarTransacao);
        EditarTransacaoCommand = new RelayCommand(EditarTransacao, () => _transacaoSelecionada != null);
        ExcluirTransacaoCommand = new RelayCommand(ExcluirTransacao, () => _transacaoSelecionada != null);
        ListarTransacoesCommand = new RelayCommand(ListarTransacoes);
        FiltrarTransacoesCommand = new RelayCommand(FiltrarTransacoes);
    }

    public IRelayCommand CriarTransacaoCommand { get; }
    public IRelayCommand EditarTransacaoCommand { get; }
    public IRelayCommand ExcluirTransacaoCommand { get; }
    public IRelayCommand ListarTransacoesCommand { get; }
    public IRelayCommand FiltrarTransacoesCommand { get; }

    private void CriarTransacao()
    {
        if (string.IsNullOrWhiteSpace(Descricao) || Tipo == null || Valor <= 0)
        {
            MessageBox.Show("Preencha todos os campos corretamente!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var novaTransacao = new TransacaoFinanceira
        {
            Descricao = Descricao,
            Tipo = Tipo.Value, // Utilizando Tipo como bool
            Data = Data,
            Valor = Valor
        };

        _financeiroService.CriarTransacao(novaTransacao);
        _transacoes.Add(novaTransacao);
        AtualizarSaldo();

        // Limpar os campos após criar
        Descricao = string.Empty;
        Tipo = null; // Deixando o ComboBox vazio após criar
        Data = DateTime.Now;
        Valor = 0;
    }

    private void EditarTransacao()
    {
        if (_transacaoSelecionada != null)
        {
            _transacaoSelecionada.Descricao = Descricao;
            _transacaoSelecionada.Tipo = Tipo ?? false; // Utilizando Tipo como bool
            _transacaoSelecionada.Data = Data;
            _transacaoSelecionada.Valor = Valor;

            _financeiroService.AtualizarTransacao(_transacaoSelecionada);
            ListarTransacoes();
            AtualizarSaldo();
        }
    }

    private void ExcluirTransacao()
    {
        if (_transacaoSelecionada != null)
        {
            _financeiroService.ExcluirTransacao(_transacaoSelecionada.Id);
            _transacoes.Remove(_transacaoSelecionada);
            TransacaoSelecionada = null;
            AtualizarSaldo();
        }
    }

    private void ListarTransacoes()
    {
        Transacoes = new ObservableCollection<TransacaoFinanceira>(_financeiroService.ListarTransacoes());
        AtualizarSaldo();
    }

    private void FiltrarTransacoes()
    {
        var inicio = DateTime.Now.AddMonths(-1); // Exemplo: últimos 30 dias
        var fim = DateTime.Now;
        Transacoes = new ObservableCollection<TransacaoFinanceira>(_financeiroService.FiltrarTransacoesPorData(inicio, fim));
    }

    private void AtualizarSaldo()
    {
        SaldoAtual = _financeiroService.CalcularSaldoAtual();
    }

    partial void OnTransacaoSelecionadaChanged(TransacaoFinanceira value)
    {
        EditarTransacaoCommand.NotifyCanExecuteChanged();
        ExcluirTransacaoCommand.NotifyCanExecuteChanged();

        if (value != null)
        {
            Descricao = value.Descricao;
            Tipo = value.Tipo;
            Data = value.Data;
            Valor = value.Valor;
        }
        else
        {
            Descricao = string.Empty;
            Tipo = null; // Deixando o ComboBox vazio quando nada está selecionado
            Data = DateTime.Now;
            Valor = 0;
        }
    }
}
