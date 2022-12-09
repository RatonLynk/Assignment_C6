using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_True.Shared.Migrations
{
    public partial class siete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Lop_MaLopNavigationMaLop",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_MaLopNavigationMaLop",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "MaLopNavigationMaLop",
                table: "SinhVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaLopNavigationMaLop",
                table: "SinhVien",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaLopNavigationMaLop",
                table: "SinhVien",
                column: "MaLopNavigationMaLop");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Lop_MaLopNavigationMaLop",
                table: "SinhVien",
                column: "MaLopNavigationMaLop",
                principalTable: "Lop",
                principalColumn: "MaLop");
        }
    }
}
