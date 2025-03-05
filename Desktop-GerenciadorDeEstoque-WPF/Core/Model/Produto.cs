namespace Desktop_GerenciadorDeEstoque_WPF.Core.Model;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorDeCusto { get; set; }
    public decimal ValorVenda { get; set; }
    public DateTime DataCadastro { get; set; } =  DateTime.Now;
}