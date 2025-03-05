namespace Desktop_GerenciadorDeEstoque_WPF.Core.Model;

public class Venda
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public Produto Produto { get; set; }
}