using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KouMobile.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class renamed_rest_service_configs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endpoints_RestServiceConfig_RestServiceConfigId",
                table: "Endpoints");

            migrationBuilder.DropForeignKey(
                name: "FK_HttpParameter_RestServiceConfig_RestServiceConfigId",
                table: "HttpParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_RestServiceConfig_Projects_ProjectId",
                table: "RestServiceConfig");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestServiceConfig",
                table: "RestServiceConfig");

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

            migrationBuilder.RenameTable(
                name: "RestServiceConfig",
                newName: "RestServiceConfigs");

            migrationBuilder.RenameIndex(
                name: "IX_RestServiceConfig_ProjectId",
                table: "RestServiceConfigs",
                newName: "IX_RestServiceConfigs_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestServiceConfigs",
                table: "RestServiceConfigs",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e25a522-a7db-4c30-b3ce-9898114e4ae7", null, "Member", "MEMBER" },
                    { "e1240489-d7ec-458f-8cda-da33ad0c7974", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NameSurname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "71c60eee-a5eb-4e4f-adb6-68d286fca7ec", 0, "81396d1a-77c4-4523-b276-62c80dd2f727", "admin@koumobilio.com", true, false, null, "Koumobilio Admin", "ADMIN@KOUMOBILIO.COM", "ADMIN", "AQAAAAIAAYagAAAAEJBl09Uv8TXNdTMsY7xdt0Oqz2hwBVQLJeJhBTbY0qWGtT8U2F0gwFBhbZJOhYG3qw==", null, false, null, false, "admin" },
                    { "e4cff733-7468-42ef-aecf-5371910c8035", 0, "5414e707-cbc4-4071-9afb-3d348c688cd6", "member@koumobilio.com", true, false, null, "Koumobilio Member", "MEMBER@KOUMOBILIO.COM", "MEMBER", "AQAAAAIAAYagAAAAEA5m5JTHAI+n6+vR0+FrkvR65Eeodu/ePYc33G9vq11BpNRGbl4TYzn7bTaXRGgFBA==", null, false, null, false, "member" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e1240489-d7ec-458f-8cda-da33ad0c7974", "71c60eee-a5eb-4e4f-adb6-68d286fca7ec" },
                    { "6e25a522-a7db-4c30-b3ce-9898114e4ae7", "e4cff733-7468-42ef-aecf-5371910c8035" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Endpoints_RestServiceConfigs_RestServiceConfigId",
                table: "Endpoints",
                column: "RestServiceConfigId",
                principalTable: "RestServiceConfigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HttpParameter_RestServiceConfigs_RestServiceConfigId",
                table: "HttpParameter",
                column: "RestServiceConfigId",
                principalTable: "RestServiceConfigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestServiceConfigs_Projects_ProjectId",
                table: "RestServiceConfigs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endpoints_RestServiceConfigs_RestServiceConfigId",
                table: "Endpoints");

            migrationBuilder.DropForeignKey(
                name: "FK_HttpParameter_RestServiceConfigs_RestServiceConfigId",
                table: "HttpParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_RestServiceConfigs_Projects_ProjectId",
                table: "RestServiceConfigs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestServiceConfigs",
                table: "RestServiceConfigs");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e1240489-d7ec-458f-8cda-da33ad0c7974", "71c60eee-a5eb-4e4f-adb6-68d286fca7ec" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6e25a522-a7db-4c30-b3ce-9898114e4ae7", "e4cff733-7468-42ef-aecf-5371910c8035" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e25a522-a7db-4c30-b3ce-9898114e4ae7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1240489-d7ec-458f-8cda-da33ad0c7974");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c60eee-a5eb-4e4f-adb6-68d286fca7ec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4cff733-7468-42ef-aecf-5371910c8035");

            migrationBuilder.RenameTable(
                name: "RestServiceConfigs",
                newName: "RestServiceConfig");

            migrationBuilder.RenameIndex(
                name: "IX_RestServiceConfigs_ProjectId",
                table: "RestServiceConfig",
                newName: "IX_RestServiceConfig_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestServiceConfig",
                table: "RestServiceConfig",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Endpoints_RestServiceConfig_RestServiceConfigId",
                table: "Endpoints",
                column: "RestServiceConfigId",
                principalTable: "RestServiceConfig",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HttpParameter_RestServiceConfig_RestServiceConfigId",
                table: "HttpParameter",
                column: "RestServiceConfigId",
                principalTable: "RestServiceConfig",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestServiceConfig_Projects_ProjectId",
                table: "RestServiceConfig",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
