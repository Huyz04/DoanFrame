using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_DOAN.Migrations
{
    /// <inheritdoc />
    public partial class Identity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "AspNetUsers");
        }
    }
}
