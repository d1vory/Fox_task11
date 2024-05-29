using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task11.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpenseCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseTypes_ExpenseCategories_ExpenseCategoryId",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsTaxable = table.Column<bool>(type: "bit", nullable: false),
                    IncomeCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeTypes_IncomeCategories_IncomeCategoryId",
                        column: x => x.IncomeCategoryId,
                        principalTable: "IncomeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IncomeTypeId = table.Column<int>(type: "int", nullable: true),
                    ExpenseTypeId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialOperations_ExpenseTypes_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "ExpenseTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialOperations_IncomeTypes_IncomeTypeId",
                        column: x => x.IncomeTypeId,
                        principalTable: "IncomeTypes",
                        principalColumn: "Id");
                });

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
                name: "IX_ExpenseTypes_ExpenseCategoryId",
                table: "ExpenseTypes",
                column: "ExpenseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialOperations_ExpenseTypeId",
                table: "FinancialOperations",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialOperations_IncomeTypeId",
                table: "FinancialOperations",
                column: "IncomeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTypes_IncomeCategoryId",
                table: "IncomeTypes",
                column: "IncomeCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialOperations");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "IncomeTypes");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "IncomeCategories");
        }
    }
}
