using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task11.Data.Migrations
{
    /// <inheritdoc />
    public partial class operationtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialOperations_ExpenseTypes_ExpenseTypeId",
                table: "FinancialOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialOperations_IncomeTypes_IncomeTypeId",
                table: "FinancialOperations");

            migrationBuilder.DropIndex(
                name: "IX_FinancialOperations_ExpenseTypeId",
                table: "FinancialOperations");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IncomeCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IncomeCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IncomeCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ExpenseTypeId",
                table: "FinancialOperations");

            migrationBuilder.RenameColumn(
                name: "IncomeTypeId",
                table: "FinancialOperations",
                newName: "OperationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialOperations_IncomeTypeId",
                table: "FinancialOperations",
                newName: "IX_FinancialOperations_OperationTypeId");

            migrationBuilder.CreateTable(
                name: "OperationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTaxable = table.Column<bool>(type: "bit", nullable: false),
                    IsIncome = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialOperations_OperationType_OperationTypeId",
                table: "FinancialOperations",
                column: "OperationTypeId",
                principalTable: "OperationType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialOperations_OperationType_OperationTypeId",
                table: "FinancialOperations");

            migrationBuilder.DropTable(
                name: "OperationType");

            migrationBuilder.RenameColumn(
                name: "OperationTypeId",
                table: "FinancialOperations",
                newName: "IncomeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialOperations_OperationTypeId",
                table: "FinancialOperations",
                newName: "IX_FinancialOperations_IncomeTypeId");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseTypeId",
                table: "FinancialOperations",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Transportation" },
                    { 3, "Housing" },
                    { 4, "Utilities" },
                    { 5, "Clothing" },
                    { 6, "Personal" }
                });

            migrationBuilder.InsertData(
                table: "IncomeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Earned" },
                    { 2, "Passive" },
                    { 3, "Portfolio" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "ExpenseCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Groceries" },
                    { 2, 1, "Restaurants" },
                    { 3, 2, "Gas" },
                    { 4, 2, "Gas" },
                    { 5, 2, "Repairs" },
                    { 6, 2, "Car payment" },
                    { 7, 3, "Mortgage or rent" },
                    { 8, 3, "Household repairs" },
                    { 9, 4, "Electricity" },
                    { 10, 4, "Water" },
                    { 11, 4, "Internet" },
                    { 12, 5, "Adults’ clothing" },
                    { 13, 6, "Gym memberships" },
                    { 14, 6, "Haircuts" },
                    { 15, 6, "Subscriptions" }
                });

            migrationBuilder.InsertData(
                table: "IncomeTypes",
                columns: new[] { "Id", "Description", "IncomeCategoryId", "IsTaxable", "Name" },
                values: new object[,]
                {
                    { 1, "", 1, true, "Salary" },
                    { 2, "For example, taxi drivers and restaurant servers can earn tips. And people who work in sales can earn commissions", 1, true, "Bonus" },
                    { 3, "short-term jobs performing a single task on demand", 1, true, "Side hustle" },
                    { 4, "", 2, true, "Rental " },
                    { 5, "", 2, true, "Royalties" },
                    { 6, "", 2, true, "Social help" },
                    { 7, "", 3, true, "dividends " },
                    { 8, "", 3, true, "capital gains on investments " },
                    { 9, "", 3, true, "deposit interest" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialOperations_ExpenseTypeId",
                table: "FinancialOperations",
                column: "ExpenseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialOperations_ExpenseTypes_ExpenseTypeId",
                table: "FinancialOperations",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialOperations_IncomeTypes_IncomeTypeId",
                table: "FinancialOperations",
                column: "IncomeTypeId",
                principalTable: "IncomeTypes",
                principalColumn: "Id");
        }
    }
}
