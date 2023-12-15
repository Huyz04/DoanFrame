using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_DOAN.Migrations
{
    /// <inheritdoc />
    public partial class Diachithem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Xa",
                table: "Diachis",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Xa",
                table: "Diachis");
        }
    }
}
