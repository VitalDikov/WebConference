using Microsoft.EntityFrameworkCore.Migrations;

namespace IntershipProject.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6",
                column: "ConcurrencyStamp",
                value: "9194992a-3047-40fa-b6b4-fe45d73e5b11");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa589457-cfcf-425f-a74d-fa098b0cd513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "080904e4-7741-4e5d-ac2a-f90753ec67fc", "AQAAAAEAACcQAAAAEAobRzoREcO+GRWGBP1ndKHXWTM8dP3dbnkPzguR6Da2xgasnJUDEY9OGnQiCSNA7w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6",
                column: "ConcurrencyStamp",
                value: "e9e95c7b-e628-4fd0-a69e-5ed441ca7442");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa589457-cfcf-425f-a74d-fa098b0cd513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63004be9-50fb-43a2-bafe-4446eac5806e", "AQAAAAEAACcQAAAAEDSVXLt+U8jS68cCw9KkVJcLkKobt8sTeZMqy2wudA+swwBiXSwbg399FisdWMwzcQ==" });
        }
    }
}
