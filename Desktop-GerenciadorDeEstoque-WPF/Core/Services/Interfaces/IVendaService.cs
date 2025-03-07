using System;
using System.Collections.Generic;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces
{
    public interface IVendaService
    {
        void RegistrarVenda(Venda venda);
        void EditarVenda(Venda venda);
        void ExcluirVenda(int id);
        Venda ObterVendaPorId(int id);
        List<Venda> ListarVendas();
        List<Venda> FiltrarVendasPorData(DateTime inicio, DateTime fim);
        decimal CalcularTotalVendas();
    }
}
