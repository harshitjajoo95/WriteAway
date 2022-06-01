using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySpace.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(nullable: false),
                    WrittenData = table.Column<string>(nullable: true),
                    UtcDateTime = table.Column<DateTime>(nullable: false),
                    LocalDateTime = table.Column<DateTime>(nullable: false),
                    TimeDifferenceInMinutes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Days");
        }
    }
}
