using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employ_of_Company.Migrations
{
    /// <inheritdoc />
    public partial class addingEmployInToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employs",
                columns: new[] { "Id", "CreatedDate", "Name", "Phone", "Position" },
                values: new object[] { 1, new DateTime(2024, 2, 23, 12, 55, 35, 250, DateTimeKind.Local).AddTicks(5807), "eken", "1234567890", "BOSS" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employs");
        }
    }
}
