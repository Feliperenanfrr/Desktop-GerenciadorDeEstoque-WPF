using System;
using System.Collections.Generic;
using System.Linq;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;
using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using Desktop_GerenciadorDeEstoque_WPF.Data;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services
{
    public class VendaService : IVendaService
    {
        private readonly AppDbContext _context;

        public VendaService(AppDbContext context)
        {
            _context = context;
        }

        public void RegistrarVenda(Venda venda)
        {
            if (venda == null || venda.Produto == null || venda.Quantidade <= 0 || venda.PrecoTotalVenda <= 0)
                throw new ArgumentException("Venda inválida. Verifique os dados informados.");

            var produto = _context.Produtos.Find(venda.Produto.Id);
            if (produto == null)
                throw new ArgumentException("Produto não encontrado.");

            if (produto.Quantidade < venda.Quantidade)
                throw new InvalidOperationException("Estoque insuficiente para realizar a venda.");

            produto.Quantidade -= venda.Quantidade;

            _context.Vendas.Add(venda);
            _context.SaveChanges();
        }

        public void EditarVenda(Venda venda)
        {
            var vendaExistente = _context.Vendas.Find(venda.Id);
            if (vendaExistente == null)
                throw new ArgumentException("Venda não encontrada.");

            vendaExistente.Quantidade = venda.Quantidade;
            vendaExistente.Produto = venda.Produto;
            vendaExistente.DataVenda = venda.DataVenda;
            vendaExistente.PrecoTotalVenda = venda.PrecoTotalVenda;

            _context.SaveChanges();
        }

        public void ExcluirVenda(int id)
        {
            var venda = _context.Vendas.Find(id);
            if (venda == null)
                throw new ArgumentException("Venda não encontrada.");

            _context.Vendas.Remove(venda);
            _context.SaveChanges();
        }

        public Venda ObterVendaPorId(int id)
        {
            return _context.Vendas.Find(id);
        }

        public List<Venda> ListarVendas()
        {
            return _context.Vendas.ToList();
        }

        public List<Venda> FiltrarVendasPorData(DateTime inicio, DateTime fim)
        {
            return _context.Vendas.Where(v => v.DataVenda >= inicio && v.DataVenda <= fim).ToList();
        }

        public decimal CalcularTotalVendas()
        {
            return _context.Vendas.Sum(v => v.PrecoTotalVenda);
        }
    }
}
