using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_DOAN.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taikhoan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matkhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phanloai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taikhoan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chitietdons",
                columns: table => new
                {
                    Madon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soluong = table.Column<int>(type: "int", nullable: true),
                    Dongia = table.Column<int>(type: "int", nullable: true),
                    SanphamId = table.Column<int>(type: "int", nullable: true),
                    TaikhoanId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietdons", x => x.Madon);
                    table.ForeignKey(
                        name: "FK_Chitietdons_Taikhoan_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "Taikhoan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ctghs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soluong = table.Column<int>(type: "int", nullable: true),
                    SanphamId = table.Column<int>(type: "int", nullable: true),
                    TaikhoanId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ctghs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ctghs_Taikhoan_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "Taikhoan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Diachis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotennguoinhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diachichitiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaikhoanId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diachis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diachis_Taikhoan_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "Taikhoan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loaisanphams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenlsp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tinhtrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaikhoanId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loaisanphams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loaisanphams_Taikhoan_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "Taikhoan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phiships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phi = table.Column<int>(type: "int", nullable: true),
                    Thoigian = table.Column<int>(type: "int", nullable: true),
                    TaikhoanId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phiships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phiships_Taikhoan_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "Taikhoan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Donhangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tongtien = table.Column<int>(type: "int", nullable: true),
                    Ngaytao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ngaygiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phuongthucthanhtoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trangthaithanhtoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trangthaidonhang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiachiId = table.Column<int>(type: "int", nullable: true),
                    TaikhoanId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donhangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donhangs_Diachis_DiachiId",
                        column: x => x.DiachiId,
                        principalTable: "Diachis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Donhangs_Taikhoan_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "Taikhoan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sanphams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tensp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dongia = table.Column<int>(type: "int", nullable: true),
                    Soluongdaban = table.Column<int>(type: "int", nullable: true),
                    Soluongtonkho = table.Column<int>(type: "int", nullable: true),
                    Tinhtrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaisanphamId = table.Column<int>(type: "int", nullable: false),
                    TaikhoanId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanphams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sanphams_Loaisanphams_LoaisanphamId",
                        column: x => x.LoaisanphamId,
                        principalTable: "Loaisanphams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sanphams_Taikhoan_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "Taikhoan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Danhgias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Danhgiaa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    SanphamId = table.Column<int>(type: "int", nullable: true),
                    TaikhoanId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhgias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Danhgias_Sanphams_SanphamId",
                        column: x => x.SanphamId,
                        principalTable: "Sanphams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Danhgias_Taikhoan_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "Taikhoan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chitietdons_TaikhoanId",
                table: "Chitietdons",
                column: "TaikhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Ctghs_TaikhoanId",
                table: "Ctghs",
                column: "TaikhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Danhgias_SanphamId",
                table: "Danhgias",
                column: "SanphamId");

            migrationBuilder.CreateIndex(
                name: "IX_Danhgias_TaikhoanId",
                table: "Danhgias",
                column: "TaikhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Diachis_TaikhoanId",
                table: "Diachis",
                column: "TaikhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Donhangs_DiachiId",
                table: "Donhangs",
                column: "DiachiId");

            migrationBuilder.CreateIndex(
                name: "IX_Donhangs_TaikhoanId",
                table: "Donhangs",
                column: "TaikhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loaisanphams_TaikhoanId",
                table: "Loaisanphams",
                column: "TaikhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Phiships_TaikhoanId",
                table: "Phiships",
                column: "TaikhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanphams_LoaisanphamId",
                table: "Sanphams",
                column: "LoaisanphamId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanphams_TaikhoanId",
                table: "Sanphams",
                column: "TaikhoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitietdons");

            migrationBuilder.DropTable(
                name: "Ctghs");

            migrationBuilder.DropTable(
                name: "Danhgias");

            migrationBuilder.DropTable(
                name: "Donhangs");

            migrationBuilder.DropTable(
                name: "Phiships");

            migrationBuilder.DropTable(
                name: "Sanphams");

            migrationBuilder.DropTable(
                name: "Diachis");

            migrationBuilder.DropTable(
                name: "Loaisanphams");

            migrationBuilder.DropTable(
                name: "Taikhoan");
        }
    }
}
