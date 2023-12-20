using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_DOAN.Migrations
{
    /// <inheritdoc />
    public partial class Chitietdon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Madon",
                table: "Chitietdons",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "DonhangId",
                table: "Chitietdons",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonhangId",
                table: "Chitietdons");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Chitietdons",
                newName: "Madon");
        }
    }
}
