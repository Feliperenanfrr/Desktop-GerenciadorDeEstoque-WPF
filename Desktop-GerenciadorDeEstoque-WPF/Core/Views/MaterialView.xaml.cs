﻿using System.Windows;
using System.Windows.Controls;
using Desktop_GerenciadorDeEstoque_WPF.Core.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Views
{
    public partial class MaterialView : UserControl
    {
        public MaterialView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<MaterialViewModel>();
        }

        public MaterialView(MaterialViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}