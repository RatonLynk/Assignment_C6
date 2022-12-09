using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_True.Shared.Migrations
{
    public partial class seis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Lop",
                table: "SinhVien");

            migrationBuilder.RenameColumn(
                name: "MaLop",
                table: "SinhVien",
                newName: "MaLopNavigationMaLop");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVien_MaLop",
                table: "SinhVien",
                newName: "IX_SinhVien_MaLopNavigationMaLop");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Lop_MaLopNavigationMaLop",
                table: "SinhVien",
                column: "MaLopNavigationMaLop",
                principalTable: "Lop",
                principalColumn: "MaLop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Lop_MaLopNavigationMaLop",
                table: "SinhVien");

            migrationBuilder.RenameColumn(
                name: "MaLopNavigationMaLop",
                table: "SinhVien",
                newName: "MaLop");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVien_MaLopNavigationMaLop",
                table: "SinhVien",
                newName: "IX_SinhVien_MaLop");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Lop",
                table: "SinhVien",
                column: "MaLop",
                principalTable: "Lop",
                principalColumn: "MaLop");
        }
    }
}
