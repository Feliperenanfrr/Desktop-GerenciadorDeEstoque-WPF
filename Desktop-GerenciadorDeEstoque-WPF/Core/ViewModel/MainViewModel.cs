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
        public RelayCommand VendaViewCommand { get; set; }
        public RelayCommand FinanceiroViewCommand { get; set; }
        public RelayCommand MaterialViewCommand { get; set; }
        public RelayCommand DashboardViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public ProdutoViewModel ProdutoVM { get; set; }
        public VendaViewModel VendaVM { get; set; }
        public FinanceiroViewModel FinanceiroVM { get; set; }
        public MaterialViewModel MaterialVM { get; set; }
        public DashboardViewModel DashboardVM { get; set; }


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

        public MainViewModel(VendaViewModel vendaVM, ProdutoViewModel produtoVM, FinanceiroViewModel financeiroVM, 
            MaterialViewModel materialVM, DashboardViewModel dashboardVM)
        {
            HomeVM = new HomeViewModel();
            ProdutoVM = produtoVM;
            VendaVM = vendaVM;
            FinanceiroVM = financeiroVM;
            MaterialVM = materialVM;
            DashboardVM = dashboardVM;
            CurrentView = HomeVM;


            HomeViewCommand = new RelayCommand(() =>
            {
                CurrentView = HomeVM;
            });


            ProdutoViewCommand = new RelayCommand(() => 
            {
                CurrentView = ProdutoVM;
            });

            VendaViewCommand = new RelayCommand(() =>
            {
                CurrentView = VendaVM;
            });

            FinanceiroViewCommand = new RelayCommand(() =>
            {
                CurrentView = FinanceiroVM;
            });

            MaterialViewCommand = new RelayCommand(() =>
            {
                CurrentView = MaterialVM;
            });

            DashboardViewCommand = new RelayCommand(() =>
            {
                CurrentView = DashboardVM;
            });
        }
    }
}
