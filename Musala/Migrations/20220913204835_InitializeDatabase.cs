using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Musala.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SerialNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Model = table.Column<int>(type: "integer", nullable: false),
                    WeightLimit = table.Column<double>(type: "double precision", nullable: false),
                    BatteryCapacity = table.Column<double>(type: "double precision", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DroneLoad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DroneId = table.Column<int>(type: "integer", nullable: false),
                    MedicationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DroneLoad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drone");

            migrationBuilder.DropTable(
                name: "DroneLoad");

            migrationBuilder.DropTable(
                name: "Medication");
        }
    }
}
