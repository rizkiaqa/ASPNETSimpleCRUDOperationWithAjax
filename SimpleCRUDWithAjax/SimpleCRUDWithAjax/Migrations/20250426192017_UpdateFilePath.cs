using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUDWithAjax.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFilePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileBinary",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Product");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBinary",
                table: "Product",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
