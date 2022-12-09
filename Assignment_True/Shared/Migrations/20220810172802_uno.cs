using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_True.Shared.Migrations
{
    public partial class uno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Truong",
                columns: table => new
                {
                    MaTruong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTruong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truong", x => x.MaTruong);
                });

            migrationBuilder.CreateTable(
                name: "Nganh",
                columns: table => new
                {
                    MaNganh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNganh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaTruong = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nganh", x => x.MaNganh);
                    table.ForeignKey(
                        name: "FK_Nganh_Truong",
                        column: x => x.MaTruong,
                        principalTable: "Truong",
                        principalColumn: "MaTruong");
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    MaMonHoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenMonHoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaTruong = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaNganh = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.MaMonHoc);
                    table.ForeignKey(
                        name: "FK_MonHoc_Nganh",
                        column: x => x.MaNganh,
                        principalTable: "Nganh",
                        principalColumn: "MaNganh");
                    table.ForeignKey(
                        name: "FK_MonHoc_Truong",
                        column: x => x.MaTruong,
                        principalTable: "Truong",
                        principalColumn: "MaTruong");
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaTruong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    MaMonHocNavigationMaMonHoc = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.MaLop);
                    table.ForeignKey(
                        name: "FK_Lop_MonHoc_MaMonHocNavigationMaMonHoc",
                        column: x => x.MaMonHocNavigationMaMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc");
                    table.ForeignKey(
                        name: "FK_Lop_Truong",
                        column: x => x.MaTruong,
                        principalTable: "Truong",
                        principalColumn: "MaTruong");
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: false),
                    MaTruong = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaNganh = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaLop = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Anh = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK_SinhVien_Lop",
                        column: x => x.MaLop,
                        principalTable: "Lop",
                        principalColumn: "MaLop");
                    table.ForeignKey(
                        name: "FK_SinhVien_Nganh",
                        column: x => x.MaNganh,
                        principalTable: "Nganh",
                        principalColumn: "MaNganh");
                    table.ForeignKey(
                        name: "FK_SinhVien_Truong",
                        column: x => x.MaTruong,
                        principalTable: "Truong",
                        principalColumn: "MaTruong");
                });

            migrationBuilder.CreateTable(
                name: "Diem",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMonHoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiemDocument = table.Column<double>(type: "float", nullable: false),
                    DiemPresentation = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diem", x => new { x.MaSV, x.MaMonHoc });
                    table.ForeignKey(
                        name: "FK_Diem_MonHoc",
                        column: x => x.MaMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc");
                    table.ForeignKey(
                        name: "FK_Diem_SinhVien",
                        column: x => x.MaSV,
                        principalTable: "SinhVien",
                        principalColumn: "MaSV");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diem_MaMonHoc",
                table: "Diem",
                column: "MaMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_Lop_MaMonHocNavigationMaMonHoc",
                table: "Lop",
                column: "MaMonHocNavigationMaMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_Lop_MaTruong",
                table: "Lop",
                column: "MaTruong");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaNganh",
                table: "MonHoc",
                column: "MaNganh");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaTruong",
                table: "MonHoc",
                column: "MaTruong");

            migrationBuilder.CreateIndex(
                name: "IX_Nganh_MaTruong",
                table: "Nganh",
                column: "MaTruong");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaLop",
                table: "SinhVien",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaNganh",
                table: "SinhVien",
                column: "MaNganh");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaTruong",
                table: "SinhVien",
                column: "MaTruong");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diem");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "Nganh");

            migrationBuilder.DropTable(
                name: "Truong");
        }
    }
}
