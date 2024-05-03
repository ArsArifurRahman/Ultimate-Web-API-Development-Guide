using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Symbol = table.Column<string>(type: "TEXT", nullable: false),
                    Company = table.Column<string>(type: "TEXT", nullable: false),
                    Purchase = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    LastDividend = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Industry = table.Column<string>(type: "TEXT", nullable: false),
                    MarketCapital = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    StockId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Company", "Industry", "LastDividend", "MarketCapital", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 1, "Apple Inc.", "Technology", 0.82m, 2000000000L, 150.00m, "AAPL" },
                    { 2, "Alphabet Inc.", "Technology", 10.60m, 1800000000L, 2500.00m, "GOOGL" },
                    { 3, "Microsoft Corporation", "Technology", 2.04m, 1600000000L, 300.00m, "MSFT" },
                    { 4, "Amazon.com, Inc.", "E-commerce", 0m, 1700000000L, 3300.00m, "AMZN" },
                    { 5, "Tesla, Inc.", "Automotive", 0m, 800000000L, 700.00m, "TSLA" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedOn", "Description", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 5, 3, 22, 41, 8, 372, DateTimeKind.Unspecified).AddTicks(5357), new TimeSpan(0, 6, 0, 0, 0)), "This is a great stock to invest in.", 1, "Great stock" },
                    { 2, new DateTimeOffset(new DateTime(2024, 5, 3, 22, 41, 8, 372, DateTimeKind.Unspecified).AddTicks(5362), new TimeSpan(0, 6, 0, 0, 0)), "I think this stock is overpriced.", 2, "Overpriced" },
                    { 3, new DateTimeOffset(new DateTime(2024, 5, 3, 22, 41, 8, 372, DateTimeKind.Unspecified).AddTicks(5366), new TimeSpan(0, 6, 0, 0, 0)), "This stock is undervalued.", 3, "Undervalued" },
                    { 4, new DateTimeOffset(new DateTime(2024, 5, 3, 22, 41, 8, 372, DateTimeKind.Unspecified).AddTicks(5371), new TimeSpan(0, 6, 0, 0, 0)), "Investing in this stock is high risk.", 4, "High risk" },
                    { 5, new DateTimeOffset(new DateTime(2024, 5, 3, 22, 41, 8, 372, DateTimeKind.Unspecified).AddTicks(5375), new TimeSpan(0, 6, 0, 0, 0)), "This stock pays a good dividend.", 5, "Good dividend" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StockId",
                table: "Comments",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
