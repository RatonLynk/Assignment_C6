using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_True.Shared.Migrations
{
    public partial class cinqo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Lop",
                table: "SinhVien");

            migrationBuilder.AlterColumn<string>(
                name: "MaLop",
                table: "SinhVien",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AlterColumn<string>(
                name: "MaLop",
                table: "SinhVien",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Lop",
                table: "SinhVien",
                column: "MaLop",
                principalTable: "Lop",
                principalColumn: "MaLop",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
