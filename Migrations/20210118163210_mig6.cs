using Microsoft.EntityFrameworkCore.Migrations;

namespace IntershipProject.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6",
                column: "ConcurrencyStamp",
                value: "4c7e8e3f-1881-46cb-abf1-19a9606bd3e9");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "aa589457-cfcf-425f-a74d-fa098b0cd513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "12bb42d6-be85-4f96-968e-9004532b9f21", "AQAAAAEAACcQAAAAEL848oCFXm9ZDCG+gMBD/q383a1SGW3AQpef6uzAQdERf+0plBZmL3hYThZWcFWPqw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6",
                column: "ConcurrencyStamp",
                value: "6ca04f28-5f5a-40db-aab1-7946171ef849");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "aa589457-cfcf-425f-a74d-fa098b0cd513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f801cc36-e8b6-42ba-9db9-7a2a4257be38", "AQAAAAEAACcQAAAAEICVh8oYLwsSiPX3zfByCN9AXRJ/g8NboLZ0ePYcTrRE/hKUBEUHnj4YZrCu4LA6RA==" });
        }
    }
}
