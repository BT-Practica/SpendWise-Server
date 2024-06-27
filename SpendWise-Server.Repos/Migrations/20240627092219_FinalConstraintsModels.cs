using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpendWise_Server.Repos.Migrations
{
    /// <inheritdoc />
    public partial class FinalConstraintsModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Incomes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstCurrencyId",
                table: "Exchanges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondCurrencyId1",
                table: "Exchanges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Currencies",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_FirstCurrencyId",
                table: "Exchanges",
                column: "FirstCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_SecondCurrencyId1",
                table: "Exchanges",
                column: "SecondCurrencyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_Currencies_FirstCurrencyId",
                table: "Exchanges",
                column: "FirstCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_Currencies_SecondCurrencyId1",
                table: "Exchanges",
                column: "SecondCurrencyId1",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_Currencies_FirstCurrencyId",
                table: "Exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_Currencies_SecondCurrencyId1",
                table: "Exchanges");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Exchanges_FirstCurrencyId",
                table: "Exchanges");

            migrationBuilder.DropIndex(
                name: "IX_Exchanges_SecondCurrencyId1",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "FirstCurrencyId",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "SecondCurrencyId1",
                table: "Exchanges");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Currencies",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);
        }
    }
}
