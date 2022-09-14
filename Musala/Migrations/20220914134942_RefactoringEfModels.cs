using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musala.Migrations
{
    public partial class RefactoringEfModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "Medication",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "WeightLimit",
                table: "Drone",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "BatteryCapacity",
                table: "Drone",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Drone",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Drone");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Medication",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "WeightLimit",
                table: "Drone",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "BatteryCapacity",
                table: "Drone",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
