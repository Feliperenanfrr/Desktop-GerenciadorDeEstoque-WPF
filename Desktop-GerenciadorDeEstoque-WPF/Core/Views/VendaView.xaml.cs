﻿using System.Windows;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Views
{
    public partial class VendaView : Window
    {
        public VendaView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<VendaViewModel>();
        }

        public VendaView(VendaViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        
        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
