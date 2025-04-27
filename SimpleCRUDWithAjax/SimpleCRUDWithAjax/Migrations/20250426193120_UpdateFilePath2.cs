using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUDWithAjax.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFilePath2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Product",
                newName: "Stock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Product",
                newName: "Number");
        }
    }
}
