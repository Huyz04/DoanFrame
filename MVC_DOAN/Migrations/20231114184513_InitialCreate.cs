using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_DOAN.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DIACHI",
                columns: table => new
                {
                    madc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    matk = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    hotennguoinhan = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    sdt = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    tinh = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    huyen = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    diachichitiet = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DIACHI__7A21E05ACDDAFB12", x => x.madc);
                });

            migrationBuilder.CreateTable(
                name: "LOAISANPHAM",
                columns: table => new
                {
                    malsp = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    tenlsp = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    tinhtrang = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOAISANP__15F47678578B3695", x => x.malsp);
                });

            migrationBuilder.CreateTable(
                name: "PHISHIP",
                columns: table => new
                {
                    maphi = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    tinh = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    quan = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    phi = table.Column<int>(type: "int", nullable: true),
                    thoigian = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PHISHIP__0AFFEDDB0F87A23F", x => x.maphi);
                });

            migrationBuilder.CreateTable(
                name: "TAIKHOAN",
                columns: table => new
                {
                    matk = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    matkhau = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    phanloai = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    nickname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TAIKHOAN__7A217E16F62E120F", x => x.matk);
                });

            migrationBuilder.CreateTable(
                name: "DONHANG",
                columns: table => new
                {
                    madon = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    madc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    tongtien = table.Column<int>(type: "int", nullable: true),
                    ngaytao = table.Column<DateTime>(type: "date", nullable: true),
                    ngaygiao = table.Column<DateTime>(type: "date", nullable: true),
                    phuongthucthanhtoan = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    trangthaithanhtoan = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    trangthaidonhang = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DONHANG__0BE41677DB87ED07", x => x.madon);
                    table.ForeignKey(
                        name: "FK_DH_DC",
                        column: x => x.madc,
                        principalTable: "DIACHI",
                        principalColumn: "madc");
                });

            migrationBuilder.CreateTable(
                name: "SANPHAM",
                columns: table => new
                {
                    masp = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    malsp = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    tensp = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    dongia = table.Column<int>(type: "int", nullable: true),
                    soluongdaban = table.Column<int>(type: "int", nullable: true),
                    soluongtonkho = table.Column<int>(type: "int", nullable: true),
                    tinhtrang = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    img = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SANPHAM__7A217672565A9A74", x => x.masp);
                    table.ForeignKey(
                        name: "FK_SP_LSP",
                        column: x => x.malsp,
                        principalTable: "LOAISANPHAM",
                        principalColumn: "malsp");
                });

            migrationBuilder.CreateTable(
                name: "CHITIETDON",
                columns: table => new
                {
                    madon = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    masp = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: true),
                    dongia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHITIETD__3C460110B16E51DC", x => new { x.madon, x.masp });
                    table.ForeignKey(
                        name: "FK_DH_CTD",
                        column: x => x.madon,
                        principalTable: "DONHANG",
                        principalColumn: "madon");
                    table.ForeignKey(
                        name: "FK_SP_CTD",
                        column: x => x.masp,
                        principalTable: "SANPHAM",
                        principalColumn: "masp");
                });

            migrationBuilder.CreateTable(
                name: "CTGH",
                columns: table => new
                {
                    matk = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    masp = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CTGH__4D83697130C5FD7B", x => new { x.matk, x.masp });
                    table.ForeignKey(
                        name: "FK_SP_GH",
                        column: x => x.masp,
                        principalTable: "SANPHAM",
                        principalColumn: "masp");
                    table.ForeignKey(
                        name: "FK_TK_GH",
                        column: x => x.matk,
                        principalTable: "TAIKHOAN",
                        principalColumn: "matk");
                });

            migrationBuilder.CreateTable(
                name: "DANHGIA",
                columns: table => new
                {
                    madg = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    masp = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    matk = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    danhgiaa = table.Column<string>(type: "text", nullable: true),
                    rate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DANHGIA__7A21E026E8F4641C", x => x.madg);
                    table.ForeignKey(
                        name: "FK_SP_DG",
                        column: x => x.masp,
                        principalTable: "SANPHAM",
                        principalColumn: "masp");
                    table.ForeignKey(
                        name: "FK_TK_DG",
                        column: x => x.matk,
                        principalTable: "TAIKHOAN",
                        principalColumn: "matk");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETDON_masp",
                table: "CHITIETDON",
                column: "masp");

            migrationBuilder.CreateIndex(
                name: "IX_CTGH_masp",
                table: "CTGH",
                column: "masp");

            migrationBuilder.CreateIndex(
                name: "IX_DANHGIA_masp",
                table: "DANHGIA",
                column: "masp");

            migrationBuilder.CreateIndex(
                name: "IX_DANHGIA_matk",
                table: "DANHGIA",
                column: "matk");

            migrationBuilder.CreateIndex(
                name: "IX_DONHANG_madc",
                table: "DONHANG",
                column: "madc");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_malsp",
                table: "SANPHAM",
                column: "malsp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHITIETDON");

            migrationBuilder.DropTable(
                name: "CTGH");

            migrationBuilder.DropTable(
                name: "DANHGIA");

            migrationBuilder.DropTable(
                name: "PHISHIP");

            migrationBuilder.DropTable(
                name: "DONHANG");

            migrationBuilder.DropTable(
                name: "SANPHAM");

            migrationBuilder.DropTable(
                name: "TAIKHOAN");

            migrationBuilder.DropTable(
                name: "DIACHI");

            migrationBuilder.DropTable(
                name: "LOAISANPHAM");
        }
    }
}
