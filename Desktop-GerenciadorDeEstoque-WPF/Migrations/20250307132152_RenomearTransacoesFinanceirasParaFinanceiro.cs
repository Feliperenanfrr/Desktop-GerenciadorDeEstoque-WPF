using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desktop_GerenciadorDeEstoque_WPF.Migrations
{
    /// <inheritdoc />
    public partial class RenomearTransacoesFinanceirasParaFinanceiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TransacoesFinanceiras",
                newName: "Financeiro"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Financeiro",
                newName: "TransacoesFinanceiras"
            );

        }
    }
}
