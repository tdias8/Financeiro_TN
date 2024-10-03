using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financeiro_TN.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
    table: "NotasFiscais",
    columns: new[] { "NomePagador", "NumeroNF", "DataEmissao", "DataCobranca", "DataPagamento", "Valor", "DocNF", "DocBoleto", "Status" },
    values: new object[,]
    {
            { "Maria Silva", "NF001", DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-15), DateTime.Now.AddDays(-5), 1000.00m, "DocNF001", "Boleto001", 1 }, 
            { "João Oliveira", "NF002", DateTime.Now.AddDays(-60), DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-20), 1500.50m, "DocNF002", "Boleto002", 2 }, 
            { "Ana Santos", "NF003", DateTime.Now.AddDays(-90), DateTime.Now.AddDays(-70), null, 1200.75m, "DocNF003", "Boleto003", 3 }, 
            { "Carlos Pereira", "NF004", DateTime.Now.AddDays(-25), DateTime.Now.AddDays(-10), null, 900.00m, "DocNF004", "Boleto004", 1 },
            { "Fernanda Costa", "NF005", DateTime.Now.AddDays(-50), DateTime.Now.AddDays(-25), DateTime.Now.AddDays(-5), 800.25m, "DocNF005", "Boleto005", 4 }, 
            { "Ricardo Lima", "NF006", DateTime.Now.AddDays(-80), DateTime.Now.AddDays(-60), null, 1100.00m, "DocNF006", "Boleto006", 2 }, 
            { "Juliana Almeida", "NF007", DateTime.Now.AddDays(-100), DateTime.Now.AddDays(-85), null, 1300.00m, "DocNF007", "Boleto007", 3 }, 
            { "Thiago Martins", "NF008", DateTime.Now.AddDays(-45), DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-10), 950.50m, "DocNF008", "Boleto008", 4 },
            { "Sofia Rocha", "NF009", DateTime.Now.AddDays(-35), DateTime.Now.AddDays(-18), null, 1050.60m, "DocNF009", "Boleto009", 1 }, 
            { "Lucas Ferreira", "NF010", DateTime.Now.AddDays(-120), DateTime.Now.AddDays(-90), DateTime.Now.AddDays(-60), 1400.40m, "DocNF010", "Boleto010", 4 } 
    }
);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM NotasFiscais");
        }
    }
}
