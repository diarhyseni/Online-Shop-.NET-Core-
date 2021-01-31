using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Shop.Data.Migrations
{
    public partial class OnlineShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chairs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(nullable: true),
                    Modeli = table.Column<string>(nullable: true),
                    Ngjyra = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    LegSupport = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chairs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameConsoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(nullable: true),
                    Modeli = table.Column<string>(nullable: true),
                    Ngjyra = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Cpu = table.Column<string>(nullable: true),
                    Ram = table.Column<int>(nullable: false),
                    Storage = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Headsets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(nullable: true),
                    Modeli = table.Column<string>(nullable: true),
                    Ngjyra = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headsets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Joysticks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(nullable: true),
                    Modeli = table.Column<string>(nullable: true),
                    Ngjyra = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    BatterySize = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joysticks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(nullable: true),
                    Modeli = table.Column<string>(nullable: true),
                    Madhesia = table.Column<string>(nullable: true),
                    Cpu = table.Column<string>(nullable: true),
                    Ram = table.Column<int>(nullable: false),
                    Storage = table.Column<int>(nullable: false),
                    Graphics = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(nullable: true),
                    Modeli = table.Column<string>(nullable: true),
                    Ngjyra = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    RgbLight = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mice", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chairs");

            migrationBuilder.DropTable(
                name: "GameConsoles");

            migrationBuilder.DropTable(
                name: "Headsets");

            migrationBuilder.DropTable(
                name: "Joysticks");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "Mice");
        }
    }
}
