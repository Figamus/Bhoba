using Microsoft.EntityFrameworkCore.Migrations;

namespace Bhoba.Migrations
{
    public partial class felonBountyColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "44923ead-821e-4366-9c17-44781309b06c", "4e75fc0e-1b04-4fb6-9c5a-fb7f37664932" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "AddressId", "ApplicationUserRoleId", "FirstName", "LastName" },
                values: new object[] { "459a3d05-a6e0-4877-ab7b-bfd819fa545d", 0, "25db57e4-95a6-4dbc-93c8-5eb488f53f22", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEFPLL2sh/Hl/xZ0yR8KR/HclAaDOhwWuyBRVtOonn0MJc/YDeWxZ42IdHpBDtFAqGA==", null, false, "6f8d3c6f-9ced-4d26-a42c-799b54cc6753", false, "admin@admin.com", 1, 1, "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "459a3d05-a6e0-4877-ab7b-bfd819fa545d", "25db57e4-95a6-4dbc-93c8-5eb488f53f22" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "AddressId", "ApplicationUserRoleId", "FirstName", "LastName" },
                values: new object[] { "44923ead-821e-4366-9c17-44781309b06c", 0, "4e75fc0e-1b04-4fb6-9c5a-fb7f37664932", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEFX3eJ1lL6yZrmYziYB171u/UMTU8kPwJmqNHmMytvD5qRh+XBzfyneIJIyW4mfzcQ==", null, false, "4d2f801d-1660-4955-86ab-c0a4374d94a4", false, "admin@admin.com", 1, 1, "admin", "admin" });
        }
    }
}
