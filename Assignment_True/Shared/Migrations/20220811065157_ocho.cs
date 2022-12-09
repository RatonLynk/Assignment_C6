using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_True.Shared.Migrations
{
    public partial class ocho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaLop",
                table: "SinhVien",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaLop",
                table: "SinhVien",
                column: "MaLop");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Lop",
                table: "SinhVien",
                column: "MaLop",
                principalTable: "Lop",
                principalColumn: "MaLop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Lop",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_MaLop",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "MaLop",
                table: "SinhVien");
        }
    }
}
