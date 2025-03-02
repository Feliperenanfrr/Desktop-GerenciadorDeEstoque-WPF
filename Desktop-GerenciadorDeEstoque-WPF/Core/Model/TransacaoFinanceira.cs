namespace Desktop_GerenciadorDeEstoque_WPF.Core.Model;

public class TransacaoFinanceira
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string Tipo { get; set; } //Entrada ou saída
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
}