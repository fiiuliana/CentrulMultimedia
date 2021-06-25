using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrulMultimedia.Migrations
{
    public partial class AddFilmType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Films_FilmId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "FilmType",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Films_FilmId",
                table: "Comments",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Films_FilmId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FilmType",
                table: "Films");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Films_FilmId",
                table: "Comments",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
