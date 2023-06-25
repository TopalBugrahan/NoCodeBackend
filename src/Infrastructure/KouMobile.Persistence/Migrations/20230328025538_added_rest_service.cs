using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KouMobile.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class added_rest_service : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RestServiceConfig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestServiceConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestServiceConfig_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endpoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Method = table.Column<int>(type: "integer", nullable: false),
                    RestServiceConfigId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endpoints_RestServiceConfig_RestServiceConfigId",
                        column: x => x.RestServiceConfigId,
                        principalTable: "RestServiceConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HttpParameter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RestServiceConfigId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    IsHeaderParameter = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HttpParameter_RestServiceConfig_RestServiceConfigId",
                        column: x => x.RestServiceConfigId,
                        principalTable: "RestServiceConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26146202-dcaf-4989-8e1a-8e1d28e6cfdf", null, "Member", "MEMBER" },
                    { "41316975-2c51-4263-a806-ea40ed9df249", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NameSurname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b8181e20-dfe7-42f2-8cc7-5854b8b476a5", 0, "b37d8de8-f491-4bc8-853f-d92d1f7b7e23", "member@koumobilio.com", true, false, null, "Koumobilio Member", "MEMBER@KOUMOBILIO.COM", "MEMBER", "AQAAAAIAAYagAAAAEBwm7BxoLPdZn29YIZGIBpyLyT4wvRPNCopA9Rqub5krLTPmcxJewHIX8KJkqaimig==", null, false, null, false, "member" },
                    { "cfacefdb-9af1-4370-948a-1da65c0b8056", 0, "6e894376-f483-4407-b71c-a4c8a81d6fc0", "admin@koumobilio.com", true, false, null, "Koumobilio Admin", "ADMIN@KOUMOBILIO.COM", "ADMIN", "AQAAAAIAAYagAAAAELCw4BiqYAS5fOeClx6wIE2E7ZrkRtWNUkFWCNbb5V89WRLt0rHnqrguMzptKDtV7g==", null, false, null, false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "26146202-dcaf-4989-8e1a-8e1d28e6cfdf", "b8181e20-dfe7-42f2-8cc7-5854b8b476a5" },
                    { "41316975-2c51-4263-a806-ea40ed9df249", "cfacefdb-9af1-4370-948a-1da65c0b8056" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endpoints_RestServiceConfigId",
                table: "Endpoints",
                column: "RestServiceConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpParameter_RestServiceConfigId",
                table: "HttpParameter",
                column: "RestServiceConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_RestServiceConfig_ProjectId",
                table: "RestServiceConfig",
                column: "ProjectId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endpoints");

            migrationBuilder.DropTable(
                name: "HttpParameter");

            migrationBuilder.DropTable(
                name: "RestServiceConfig");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "26146202-dcaf-4989-8e1a-8e1d28e6cfdf", "b8181e20-dfe7-42f2-8cc7-5854b8b476a5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "41316975-2c51-4263-a806-ea40ed9df249", "cfacefdb-9af1-4370-948a-1da65c0b8056" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26146202-dcaf-4989-8e1a-8e1d28e6cfdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41316975-2c51-4263-a806-ea40ed9df249");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8181e20-dfe7-42f2-8cc7-5854b8b476a5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfacefdb-9af1-4370-948a-1da65c0b8056");

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
    }
}
