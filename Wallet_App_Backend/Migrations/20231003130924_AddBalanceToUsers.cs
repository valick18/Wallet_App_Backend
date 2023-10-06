using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallet_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddBalanceToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_seasonalPoints",
                table: "seasonalPoints");

            migrationBuilder.RenameTable(
                name: "seasonalPoints",
                newName: "seasonalpoints");

            migrationBuilder.AddColumn<int>(
                name: "balance",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "transactionname",
                table: "transactions",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_seasonalpoints",
                table: "seasonalpoints",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_seasonalpoints",
                table: "seasonalpoints");

            migrationBuilder.DropColumn(
                name: "balance",
                table: "users");

            migrationBuilder.RenameTable(
                name: "seasonalpoints",
                newName: "seasonalPoints");

            migrationBuilder.AlterColumn<int>(
                name: "transactionname",
                table: "transactions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_seasonalPoints",
                table: "seasonalPoints",
                column: "id");
        }
    }
}
