using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_True.Shared.Migrations
{
    public partial class tres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Lop",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Nganh",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Truong",
                table: "SinhVien");

            migrationBuilder.AlterColumn<string>(
                name: "MaTruong",
                table: "SinhVien",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaNganh",
                table: "SinhVien",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaLop",
                table: "SinhVien",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Anh",
                table: "SinhVien",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Lop",
                table: "SinhVien",
                column: "MaLop",
                principalTable: "Lop",
                principalColumn: "MaLop",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Nganh",
                table: "SinhVien",
                column: "MaNganh",
                principalTable: "Nganh",
                principalColumn: "MaNganh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Truong",
                table: "SinhVien",
                column: "MaTruong",
                principalTable: "Truong",
                principalColumn: "MaTruong",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Lop",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Nganh",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Truong",
                table: "SinhVien");

            migrationBuilder.AlterColumn<string>(
                name: "MaTruong",
                table: "SinhVien",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MaNganh",
                table: "SinhVien",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MaLop",
                table: "SinhVien",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Anh",
                table: "SinhVien",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Lop",
                table: "SinhVien",
                column: "MaLop",
                principalTable: "Lop",
                principalColumn: "MaLop");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Nganh",
                table: "SinhVien",
                column: "MaNganh",
                principalTable: "Nganh",
                principalColumn: "MaNganh");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Truong",
                table: "SinhVien",
                column: "MaTruong",
                principalTable: "Truong",
                principalColumn: "MaTruong");
        }
    }
}
