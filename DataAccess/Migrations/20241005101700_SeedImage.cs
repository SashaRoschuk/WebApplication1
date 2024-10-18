using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductDB.Migrations
{
    /// <inheritdoc />
    public partial class SeedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://m.media-amazon.com/images/I/615rI0PoyOL.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: null);
        }
    }
}
