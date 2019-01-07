using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bhoba.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StreetAddress = table.Column<string>(maxLength: 55, nullable: false),
                    City = table.Column<string>(maxLength: 55, nullable: false),
                    State = table.Column<string>(maxLength: 55, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 55, nullable: false),
                    Latitude = table.Column<float>(nullable: true),
                    Longitude = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicatonUserRoles",
                columns: table => new
                {
                    ApplicationUserRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicatonUserRoles", x => x.ApplicationUserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Felons",
                columns: table => new
                {
                    FelonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Alias = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Felons", x => x.FelonId);
                });

            migrationBuilder.CreateTable(
                name: "BailBondsmans",
                columns: table => new
                {
                    BailBondsmanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BailBondsmans", x => x.BailBondsmanId);
                    table.ForeignKey(
                        name: "FK_BailBondsmans_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    ApplicationUserRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_ApplicatonUserRoles_ApplicationUserRoleId",
                        column: x => x.ApplicationUserRoleId,
                        principalTable: "ApplicatonUserRoles",
                        principalColumn: "ApplicationUserRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FelonAddresses",
                columns: table => new
                {
                    FelonAddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    FelonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FelonAddresses", x => x.FelonAddressId);
                    table.ForeignKey(
                        name: "FK_FelonAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FelonAddresses_Felons_FelonId",
                        column: x => x.FelonId,
                        principalTable: "Felons",
                        principalColumn: "FelonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FelonBounties",
                columns: table => new
                {
                    FelonBountyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BailBondsmanId = table.Column<int>(nullable: false),
                    FelonId = table.Column<int>(nullable: false),
                    PoliceReportNumber = table.Column<string>(maxLength: 55, nullable: false),
                    CrimeType = table.Column<string>(maxLength: 55, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    BountyAmount = table.Column<double>(nullable: false),
                    BondClosed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FelonBounties", x => x.FelonBountyId);
                    table.ForeignKey(
                        name: "FK_FelonBounties_BailBondsmans_BailBondsmanId",
                        column: x => x.BailBondsmanId,
                        principalTable: "BailBondsmans",
                        principalColumn: "BailBondsmanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FelonBounties_Felons_FelonId",
                        column: x => x.FelonId,
                        principalTable: "Felons",
                        principalColumn: "FelonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecoveryAgents",
                columns: table => new
                {
                    RecoveryAgentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false),
                    BailBondsmanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecoveryAgents", x => x.RecoveryAgentId);
                    table.ForeignKey(
                        name: "FK_RecoveryAgents_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecoveryAgents_BailBondsmans_BailBondsmanId",
                        column: x => x.BailBondsmanId,
                        principalTable: "BailBondsmans",
                        principalColumn: "BailBondsmanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Latitude", "Longitude", "State", "StreetAddress", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Spring Hill", 35.73866f, -86.90933f, "TN", "3001 Alan Dr.", "37174" },
                    { 2, "Nashville", 36.13287f, -86.75632f, "TN", "500 Interstate Blvd.", "37210" },
                    { 3, "Spring Hill", 35.73866f, -86.90933f, "TN", "4900 Port Royal Rd.", "37174" },
                    { 4, "Madison", 36.2566f, -86.71313f, "TN", "627 Gallatin Pike S", "37115" },
                    { 5, "Franklin", 35.93497f, -86.82579f, "TN", "1556 W McEwen Dr.", "37067" },
                    { 6, "Franklin", 35.93497f, -86.82579f, "TN", "1556 W McEwen Dr.", "37067" },
                    { 7, "Franklin", 35.93497f, -86.82579f, "TN", "1556 W McEwen Dr.", "37067" }
                });

            migrationBuilder.InsertData(
                table: "ApplicatonUserRoles",
                columns: new[] { "ApplicationUserRoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Recovery Agent" },
                    { 3, "Bail Bondsman" }
                });

            migrationBuilder.InsertData(
                table: "Felons",
                columns: new[] { "FelonId", "Alias", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Johnny Boy", new DateTime(1917, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe" },
                    { 2, "Miss JD", new DateTime(1987, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Doe" },
                    { 3, "JimBob", new DateTime(1997, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "Bobson" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "AddressId", "ApplicationUserRoleId", "FirstName", "LastName" },
                values: new object[] { "03a52beb-c1f9-436c-8c8e-34e5e39a2450", 0, "030ab4d1-00bc-4bc8-b7ef-e93d17f2130b", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAFChLZWAp/WIRkOKvcsHvlZLL9Q4+9tzSSgFj8pgJaW+fa56274sz2rFB7Alk97qA==", null, false, "6de3c6c7-8971-4133-b72f-d2a50f5594f6", false, "admin@admin.com", 1, 1, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "BailBondsmans",
                columns: new[] { "BailBondsmanId", "AddressId", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Hunt You Down Bailbonds, LLC" },
                    { 2, 3, "Music City Bailbonds, LLC" },
                    { 3, 4, "You Screwed Up Bailbonds, LLC" }
                });

            migrationBuilder.InsertData(
                table: "FelonAddresses",
                columns: new[] { "FelonAddressId", "AddressId", "FelonId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 6, 2 },
                    { 3, 7, 3 }
                });

            migrationBuilder.InsertData(
                table: "FelonBounties",
                columns: new[] { "FelonBountyId", "BailBondsmanId", "BondClosed", "BountyAmount", "CrimeType", "Description", "FelonId", "PoliceReportNumber" },
                values: new object[] { 1, 1, false, 10000.0, "Indecent Exposure", "Public exposure to blind people", 1, "S-0079-AJ007" });

            migrationBuilder.InsertData(
                table: "FelonBounties",
                columns: new[] { "FelonBountyId", "BailBondsmanId", "BondClosed", "BountyAmount", "CrimeType", "Description", "FelonId", "PoliceReportNumber" },
                values: new object[] { 2, 2, false, 8000.0, "Traffic Violation", "Unpaid parking violations in excess of 1,000 USD", 2, "B-0179-BB345" });

            migrationBuilder.InsertData(
                table: "FelonBounties",
                columns: new[] { "FelonBountyId", "BailBondsmanId", "BondClosed", "BountyAmount", "CrimeType", "Description", "FelonId", "PoliceReportNumber" },
                values: new object[] { 3, 3, true, 6000.0, "Breaking & Entering", "Unlawful entry into a private residence.", 1, "X-0325-PS846" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUserRoleId",
                table: "AspNetUsers",
                column: "ApplicationUserRoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BailBondsmans_AddressId",
                table: "BailBondsmans",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_FelonAddresses_AddressId",
                table: "FelonAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_FelonAddresses_FelonId",
                table: "FelonAddresses",
                column: "FelonId");

            migrationBuilder.CreateIndex(
                name: "IX_FelonBounties_BailBondsmanId",
                table: "FelonBounties",
                column: "BailBondsmanId");

            migrationBuilder.CreateIndex(
                name: "IX_FelonBounties_FelonId",
                table: "FelonBounties",
                column: "FelonId");

            migrationBuilder.CreateIndex(
                name: "IX_RecoveryAgents_AddressId",
                table: "RecoveryAgents",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_RecoveryAgents_BailBondsmanId",
                table: "RecoveryAgents",
                column: "BailBondsmanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FelonAddresses");

            migrationBuilder.DropTable(
                name: "FelonBounties");

            migrationBuilder.DropTable(
                name: "RecoveryAgents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Felons");

            migrationBuilder.DropTable(
                name: "BailBondsmans");

            migrationBuilder.DropTable(
                name: "ApplicatonUserRoles");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
