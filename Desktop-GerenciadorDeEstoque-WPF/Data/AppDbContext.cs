using System.IO;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Desktop_GerenciadorDeEstoque_WPF.Data;

public class AppDbContext : DbContext
{
    private readonly string? _connectionString;

    public AppDbContext()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection") 
                            ?? throw new InvalidOperationException("A string de conexão não foi encontrada.");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
    
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<TransacaoFinanceira> TransacoesFinanceiras { get; set; }
    public DbSet<Material> Materiais { get; set; }
    public DbSet<Venda> Vendas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.Nome).IsRequired().HasMaxLength(200);
            entity.Property(p => p.ValorVenda).HasColumnType("decimal(10,2)");
        });
        
        
    }
}
















