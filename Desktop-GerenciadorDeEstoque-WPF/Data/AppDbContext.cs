using System.IO;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;
using Microsoft.EntityFrameworkCore;
using Material = System.Windows.Media.Media3D.Material;
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

        _connectionString = configuration.GetConnectionString("PostgresConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
    
    public DbSet<Produto> Produtos;
    public DbSet<Usuario> Usuarios;
    public DbSet<TransacaoFinanceira> TransacoesFinanceiras;
    public DbSet<Material> Materiais { get; set; }
}