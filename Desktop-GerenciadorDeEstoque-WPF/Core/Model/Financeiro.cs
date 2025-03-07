namespace Desktop_GerenciadorDeEstoque_WPF.Core.Model;

public class Financeiro
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public bool Tipo { get; set; } // false = Entrada, true = Saída
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
}