using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task11.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialOperations_OperationTypes_OperationTypeId",
                table: "FinancialOperations");

            migrationBuilder.AlterColumn<int>(
                name: "OperationTypeId",
                table: "FinancialOperations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialOperations_OperationTypes_OperationTypeId",
                table: "FinancialOperations",
                column: "OperationTypeId",
                principalTable: "OperationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialOperations_OperationTypes_OperationTypeId",
                table: "FinancialOperations");

            migrationBuilder.AlterColumn<int>(
                name: "OperationTypeId",
                table: "FinancialOperations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialOperations_OperationTypes_OperationTypeId",
                table: "FinancialOperations",
                column: "OperationTypeId",
                principalTable: "OperationTypes",
                principalColumn: "Id");
        }
    }
}
