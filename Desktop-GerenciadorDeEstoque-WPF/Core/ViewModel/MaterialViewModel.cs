using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;

public partial class MaterialViewModel : ObservableObject
{
    private readonly IMaterialService _materialService;

    [ObservableProperty]
    private ObservableCollection<Material> _materiais;

    [ObservableProperty]
    private Material _materialSelecionado;

    [ObservableProperty]
    private string _nome;

    [ObservableProperty]
    private int _quantidade;

    [ObservableProperty]
    private decimal _preco;

    [ObservableProperty]
    private DateTime _dataDeCompra = DateTime.Now;

    public MaterialViewModel(IMaterialService materialService)
    {
        _materialService = materialService;
        _materiais = new ObservableCollection<Material>(_materialService.ListarMateriais());

        CriarMaterialCommand = new RelayCommand(CriarMaterial);
        EditarMaterialCommand = new RelayCommand(EditarMaterial, () => _materialSelecionado != null);
        ExcluirMaterialCommand = new RelayCommand(ExcluirMaterial, () => _materialSelecionado != null);
        ListarMateriaisCommand = new RelayCommand(ListarMateriais);
    }

    public IRelayCommand CriarMaterialCommand { get; }
    public IRelayCommand EditarMaterialCommand { get; }
    public IRelayCommand ExcluirMaterialCommand { get; }
    public IRelayCommand ListarMateriaisCommand { get; }

    private void CriarMaterial()
    {
        if (string.IsNullOrWhiteSpace(Nome) || Quantidade <= 0 || Preco <= 0)
        {
            MessageBox.Show("Preencha todos os campos corretamente!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var novoMaterial = new Material
        {
            Nome = Nome,
            Quantidade = Quantidade,
            Preco = Preco,
            DataDeCompra = DataDeCompra
        };
        
        novoMaterial.DataDeCompra = novoMaterial.DataDeCompra.ToUniversalTime();

        _materialService.CriarMaterial(novoMaterial);
        _materiais.Add(novoMaterial);

        // Limpar os campos após criar
        Nome = string.Empty;
        Quantidade = 0;
        Preco = 0;
        DataDeCompra = DateTime.Now;
    }

    private void EditarMaterial()
    {
        if (_materialSelecionado != null)
        {
            _materialSelecionado.Nome = Nome;
            _materialSelecionado.Quantidade = Quantidade;
            _materialSelecionado.Preco = Preco;
            _materialSelecionado.DataDeCompra = DataDeCompra;

            _materialService.AtualizarMaterial(_materialSelecionado);
            ListarMateriais();
        }
    }

    private void ExcluirMaterial()
    {
        if (_materialSelecionado != null)
        {
            _materialService.ExcluirMaterial(_materialSelecionado.Id);
            _materiais.Remove(_materialSelecionado);
            MaterialSelecionado = null;
        }
    }

    private void ListarMateriais()
    {
        Materiais = new ObservableCollection<Material>(_materialService.ListarMateriais());
    }

    partial void OnMaterialSelecionadoChanged(Material value)
    {
        EditarMaterialCommand.NotifyCanExecuteChanged();
        ExcluirMaterialCommand.NotifyCanExecuteChanged();

        if (value != null)
        {
            Nome = value.Nome;
            Quantidade = value.Quantidade;
            Preco = value.Preco;
            DataDeCompra = value.DataDeCompra;
        }
        else
        {
            // Limpar campos se nenhum material estiver selecionado
            Nome = string.Empty;
            Quantidade = 0;
            Preco = 0;
            DataDeCompra = DateTime.Now;
        }
    }
}
