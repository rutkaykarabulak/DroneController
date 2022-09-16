using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musala.Migrations
{
    public partial class AddImageColumnToMedication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Medication",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Medication");
        }
    }
}
