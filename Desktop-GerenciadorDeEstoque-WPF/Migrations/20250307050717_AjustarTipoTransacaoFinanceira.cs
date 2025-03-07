using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desktop_GerenciadorDeEstoque_WPF.Migrations
{
    /// <inheritdoc />
    public partial class AjustarTipoTransacaoFinanceira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE \"TransacoesFinanceiras\" " +
                "ALTER COLUMN \"Tipo\" TYPE boolean USING (CASE " +
                "WHEN \"Tipo\" ILIKE 'true' THEN TRUE " +
                "WHEN \"Tipo\" ILIKE 'false' THEN FALSE " +
                "ELSE FALSE END);"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE \"TransacoesFinanceiras\" " +
                "ALTER COLUMN \"Tipo\" TYPE text USING (CASE " +
                "WHEN \"Tipo\" = TRUE THEN 'true' " +
                "WHEN \"Tipo\" = FALSE THEN 'false' " +
                "ELSE 'false' END);"
            );
        }
    }
}