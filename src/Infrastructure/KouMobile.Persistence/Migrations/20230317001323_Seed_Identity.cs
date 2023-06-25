using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KouMobile.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "006febb9-cdc6-4795-8566-82163a30abd2", null, "Member", "MEMBER" },
                    { "e3176164-7d3a-4925-a6e0-6b6eb856ddb5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NameSurname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6af56851-86f7-4937-807b-611c1b183c7d", 0, "f4118b5b-9e42-4dd3-9b3a-39588d4a3233", "admin@koumobilio.com", true, false, null, "Koumobilio Admin", "ADMIN@KOUMOBILIO.COM", "ADMIN", "AQAAAAIAAYagAAAAELtEiUjvbR4E/maH0/XGBALhbhSUIHHpEZ69d0Cib2r1avgDYhn4/zPByL39CBrmIQ==", null, false, null, false, "admin" },
                    { "fe1359bf-4e12-4b5c-be23-cd563c3f2023", 0, "3b2723a4-885a-4883-9317-bcd2e2c3bf34", "member@koumobilio.com", true, false, null, "Koumobilio Member", "MEMBER@KOUMOBILIO.COM", "MEMBER", "AQAAAAIAAYagAAAAEPe3+7hoks4v4R8gVwBAiVEaUMaBs+iNCvM1XFSLqMvREoAESMsVSQZHrOP4a8SU3g==", null, false, null, false, "member" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e3176164-7d3a-4925-a6e0-6b6eb856ddb5", "6af56851-86f7-4937-807b-611c1b183c7d" },
                    { "006febb9-cdc6-4795-8566-82163a30abd2", "fe1359bf-4e12-4b5c-be23-cd563c3f2023" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e3176164-7d3a-4925-a6e0-6b6eb856ddb5", "6af56851-86f7-4937-807b-611c1b183c7d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "006febb9-cdc6-4795-8566-82163a30abd2", "fe1359bf-4e12-4b5c-be23-cd563c3f2023" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "006febb9-cdc6-4795-8566-82163a30abd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3176164-7d3a-4925-a6e0-6b6eb856ddb5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6af56851-86f7-4937-807b-611c1b183c7d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe1359bf-4e12-4b5c-be23-cd563c3f2023");
        }
    }
}
