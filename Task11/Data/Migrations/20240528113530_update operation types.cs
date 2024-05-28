using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task11.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateoperationtypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OperationTypes",
                columns: new[] { "Id", "Description", "IsIncome", "IsTaxable", "Name" },
                values: new object[,]
                {
                    { 1, "from working", true, true, "Salary" },
                    { 2, "tips and comissions etc", true, true, "Bonus" },
                    { 3, "short-term jobs performing a single task on demand", true, true, "Side hustle" },
                    { 4, "", true, true, "Rental" },
                    { 5, "from nice investments", true, true, "Royalties" },
                    { 6, "from nice investments 2", true, false, "dividends" },
                    { 7, "", true, true, "Food" },
                    { 8, "", false, false, "Transportation" },
                    { 9, "", false, false, "Housing" },
                    { 10, "", false, false, "Utilities" },
                    { 11, "", false, false, "Clothing" },
                    { 12, "", false, false, "Personal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OperationTypes",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
