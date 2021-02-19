using Microsoft.EntityFrameworkCore.Migrations;

namespace IntershipProject.Migrations
{
    public partial class newMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6",
                column: "ConcurrencyStamp",
                value: "ce8c72e8-ed38-44e6-ae67-e3a20067c09e");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "aa589457-cfcf-425f-a74d-fa098b0cd513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d122e3fe-2709-4d84-9831-e75ca0709abf", "AQAAAAEAACcQAAAAEOkYdRde9LYri7VHFrvoYzSNvvK4YNdVapf6g4sJfKEM6iqiqND/mLMtJFYHZV2uKA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
