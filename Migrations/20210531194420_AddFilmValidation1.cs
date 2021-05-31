using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrulMultimedia.Migrations
{
    public partial class AddFilmValidation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "Films",
                newName: "DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Films",
                newName: "DateAdded");
        }
    }
}
