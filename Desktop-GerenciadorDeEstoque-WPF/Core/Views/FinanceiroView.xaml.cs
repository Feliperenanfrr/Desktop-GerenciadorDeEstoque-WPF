﻿using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Views
{
    public partial class TransacaoView : Window
    {
        public TransacaoView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<FinanceiroViewModel>(); // Instância padrão do ViewModel
        }

        public TransacaoView(FinanceiroViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}