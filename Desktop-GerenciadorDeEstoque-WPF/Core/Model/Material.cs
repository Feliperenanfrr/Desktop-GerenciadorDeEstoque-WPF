namespace Desktop_GerenciadorDeEstoque_WPF.Core.Model;

public class Material
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int  Quantidade { get; set; }
    public DateTime DataDeCompra { get; set; }
}