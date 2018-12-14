using Microsoft.EntityFrameworkCore.Migrations;

namespace Bhoba.Migrations
{
    public partial class felonbounties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "dd05417a-60e4-4f5a-a37d-361b14ea50ef", "e73f1d6a-67ef-4ca5-b7bd-68af5d0839dc" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "AddressId", "ApplicationUserRoleId", "FirstName", "LastName" },
                values: new object[] { "44923ead-821e-4366-9c17-44781309b06c", 0, "4e75fc0e-1b04-4fb6-9c5a-fb7f37664932", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEFX3eJ1lL6yZrmYziYB171u/UMTU8kPwJmqNHmMytvD5qRh+XBzfyneIJIyW4mfzcQ==", null, false, "4d2f801d-1660-4955-86ab-c0a4374d94a4", false, "admin@admin.com", 1, 1, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "FelonBounties",
                columns: new[] { "FelonBountyId", "BailBondsmanId", "BountyAmount", "FelonId" },
                values: new object[,]
                {
                    { 1, 1, 10000.0, 1 },
                    { 2, 2, 8000.0, 2 },
                    { 3, 3, 6000.0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FelonBounties_BailBondsmanId",
                table: "FelonBounties",
                column: "BailBondsmanId");

            migrationBuilder.CreateIndex(
                name: "IX_FelonBounties_FelonId",
                table: "FelonBounties",
                column: "FelonId");

            migrationBuilder.AddForeignKey(
                name: "FK_FelonBounties_BailBondsmans_BailBondsmanId",
                table: "FelonBounties",
                column: "BailBondsmanId",
                principalTable: "BailBondsmans",
                principalColumn: "BailBondsmanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FelonBounties_Felons_FelonId",
                table: "FelonBounties",
                column: "FelonId",
                principalTable: "Felons",
                principalColumn: "FelonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FelonBounties_BailBondsmans_BailBondsmanId",
                table: "FelonBounties");

            migrationBuilder.DropForeignKey(
                name: "FK_FelonBounties_Felons_FelonId",
                table: "FelonBounties");

            migrationBuilder.DropIndex(
                name: "IX_FelonBounties_BailBondsmanId",
                table: "FelonBounties");

            migrationBuilder.DropIndex(
                name: "IX_FelonBounties_FelonId",
                table: "FelonBounties");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "44923ead-821e-4366-9c17-44781309b06c", "4e75fc0e-1b04-4fb6-9c5a-fb7f37664932" });

            migrationBuilder.DeleteData(
                table: "FelonBounties",
                keyColumn: "FelonBountyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FelonBounties",
                keyColumn: "FelonBountyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FelonBounties",
                keyColumn: "FelonBountyId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "AddressId", "ApplicationUserRoleId", "FirstName", "LastName" },
                values: new object[] { "dd05417a-60e4-4f5a-a37d-361b14ea50ef", 0, "e73f1d6a-67ef-4ca5-b7bd-68af5d0839dc", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDdoJ49SOE/iOpW7wVuZmJ5jHbSqYKthIN3FnKLbyu5xSIoK58xANCcKcpzLi6XPcg==", null, false, "5aa484b7-4666-49e1-949b-6c3fa8b9e5d0", false, "admin@admin.com", 1, 1, "admin", "admin" });
        }
    }
}
