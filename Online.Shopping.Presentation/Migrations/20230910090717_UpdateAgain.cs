using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online.Shopping.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price_Amount",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "Price_Currency",
                table: "LineItems");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "LineItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "LineItems");

            migrationBuilder.AddColumn<decimal>(
                name: "Price_Amount",
                table: "LineItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Price_Currency",
                table: "LineItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
