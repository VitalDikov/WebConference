using Microsoft.EntityFrameworkCore.Migrations;

namespace IntershipProject.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6", "e9e95c7b-e628-4fd0-a69e-5ed441ca7442", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aa589457-cfcf-425f-a74d-fa098b0cd513", 0, "63004be9-50fb-43a2-bafe-4446eac5806e", "test@ss.ru", true, false, null, "TEST@SS.RU", "TEST", "AQAAAAEAACcQAAAAEDSVXLt+U8jS68cCw9KkVJcLkKobt8sTeZMqy2wudA+swwBiXSwbg399FisdWMwzcQ==", null, false, "", false, "test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6", "aa589457-cfcf-425f-a74d-fa098b0cd513" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6", "aa589457-cfcf-425f-a74d-fa098b0cd513" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa589457-cfcf-425f-a74d-fa098b0cd513");

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserModel",
                columns: new[] { "Id", "Address", "Age", "Name", "Password", "Patronymic", "Phone", "Surname", "UserMail", "UserName" },
                values: new object[] { 1, "St. Petersburg", 21, "Тестер", "TestUser", "Тестерович", "+7-911-432-23-23", "Тестеров", "tester@test.ru", "TestUser" });
        }
    }
}
