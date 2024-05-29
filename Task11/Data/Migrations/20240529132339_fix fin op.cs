using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task11.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixfinop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "FinancialOperations",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "FinancialOperations",
                newName: "TimeStamp");
        }
    }
}
