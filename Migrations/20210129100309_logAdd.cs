using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntershipProject.Migrations
{
    public partial class logAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logging", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6",
                column: "ConcurrencyStamp",
                value: "c71433c4-a8a5-4270-8c0e-0533df8be296");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "aa589457-cfcf-425f-a74d-fa098b0cd513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe810217-3545-4e22-8c0a-435cd10ca959", "AQAAAAEAACcQAAAAEGwaEx7s8TJeNeo4gNfI2QzrvjRyePEL90cYnGNrj9MJJvF0y7MqCWsYUj7aiozdtQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logging");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6",
                column: "ConcurrencyStamp",
                value: "deba6470-2d1d-41e6-91fd-e3c22a20251b");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "aa589457-cfcf-425f-a74d-fa098b0cd513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5e0af22-a7b4-4ad4-8f5c-4f777edbb357", "AQAAAAEAACcQAAAAEKz2xj6qH+CfYLhE4leQIZ3JxjIZxw2FE0bMpGYv5+UKAqu/I7PySuL7mf1ES1wn+g==" });
        }
    }
}
