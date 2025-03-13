using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand ProdutoViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public DiscoveryViewModel DiscoveryVM { get; set; }
        public ProdutoViewModel ProdutoVM { get; set; }
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(HomeViewModel homeVM, DiscoveryViewModel discoveryVM, ProdutoViewModel produtoVM)
        {
            HomeVM = new HomeViewModel();
            DiscoveryVM = new DiscoveryViewModel();
            ProdutoVM = produtoVM;
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(() =>
            {
                CurrentView = HomeVM;
            });

            DiscoveryViewCommand = new RelayCommand(() =>
            {
                CurrentView = DiscoveryVM;
            });

            ProdutoViewCommand = new RelayCommand(() => 
            {
                CurrentView = ProdutoVM;
            });
        }
    }
}
