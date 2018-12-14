﻿// <auto-generated />
using System;
using Bhoba.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bhoba.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181214145433_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bhoba.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new { AddressId = 1, City = "Everywhere", State = "XX", StreetAddress = "123 Admin Way", ZipCode = "12345" },
                        new { AddressId = 2, City = "Everywhere2", State = "XX", StreetAddress = "223 Admin Way", ZipCode = "12345" },
                        new { AddressId = 3, City = "Everywhere3", State = "XX", StreetAddress = "323 Admin Way", ZipCode = "12345" },
                        new { AddressId = 4, City = "Everywhere4", State = "XX", StreetAddress = "423 Admin Way", ZipCode = "12345" },
                        new { AddressId = 5, City = "Everywhere5", State = "XX", StreetAddress = "523 Admin Way", ZipCode = "12345" },
                        new { AddressId = 6, City = "Everywhere6", State = "XX", StreetAddress = "623 Admin Way", ZipCode = "12345" },
                        new { AddressId = 7, City = "Everywhere7", State = "XX", StreetAddress = "723 Admin Way", ZipCode = "12345" },
                        new { AddressId = 8, City = "Everywhere8", State = "XX", StreetAddress = "823 Admin Way", ZipCode = "12345" },
                        new { AddressId = 9, City = "Everywhere9", State = "XX", StreetAddress = "923 Admin Way", ZipCode = "12345" },
                        new { AddressId = 10, City = "Everywhere10", State = "XX", StreetAddress = "1023 Admin Way", ZipCode = "12345" }
                    );
                });

            modelBuilder.Entity("Bhoba.Models.ApplicationUserRole", b =>
                {
                    b.Property<int>("ApplicationUserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.HasKey("ApplicationUserRoleId");

                    b.ToTable("ApplicatonUserRoles");

                    b.HasData(
                        new { ApplicationUserRoleId = 1, RoleName = "Admin" },
                        new { ApplicationUserRoleId = 2, RoleName = "Recovery Agent" },
                        new { ApplicationUserRoleId = 3, RoleName = "Bail Bondsman" }
                    );
                });

            modelBuilder.Entity("Bhoba.Models.BailBondsman", b =>
                {
                    b.Property<int>("BailBondsmanId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("BailBondsmanId");

                    b.HasIndex("AddressId");

                    b.ToTable("BailBondsmans");

                    b.HasData(
                        new { BailBondsmanId = 1, AddressId = 2, Name = "Hunt You Down Bailbonds, LLC" },
                        new { BailBondsmanId = 2, AddressId = 3, Name = "Music City Bailbonds, LLC" },
                        new { BailBondsmanId = 3, AddressId = 4, Name = "You Done Fucked Up Bailbonds, LLC" }
                    );
                });

            modelBuilder.Entity("Bhoba.Models.Felon", b =>
                {
                    b.Property<int>("FelonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("FelonId");

                    b.ToTable("Felons");

                    b.HasData(
                        new { FelonId = 1, Alias = "Bobo", DateOfBirth = new DateTime(1917, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), FirstName = "John", LastName = "Doe" },
                        new { FelonId = 2, Alias = "Bitch", DateOfBirth = new DateTime(1987, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), FirstName = "Jane", LastName = "Doe" },
                        new { FelonId = 3, Alias = "James", DateOfBirth = new DateTime(1997, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), FirstName = "Jim", LastName = "Bob" }
                    );
                });

            modelBuilder.Entity("Bhoba.Models.FelonAddress", b =>
                {
                    b.Property<int>("FelonAddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<int>("FelonId");

                    b.HasKey("FelonAddressId");

                    b.HasIndex("AddressId");

                    b.HasIndex("FelonId");

                    b.ToTable("FelonAddresses");

                    b.HasData(
                        new { FelonAddressId = 1, AddressId = 5, FelonId = 1 },
                        new { FelonAddressId = 2, AddressId = 6, FelonId = 2 },
                        new { FelonAddressId = 3, AddressId = 7, FelonId = 3 }
                    );
                });

            modelBuilder.Entity("Bhoba.Models.FelonBounty", b =>
                {
                    b.Property<int>("FelonBountyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BailBondsmanId");

                    b.Property<double>("BountyAmount");

                    b.Property<int>("FelonId");

                    b.HasKey("FelonBountyId");

                    b.ToTable("FelonBounties");
                });

            modelBuilder.Entity("Bhoba.Models.RecoveryAgent", b =>
                {
                    b.Property<int>("RecoveryAgentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<int?>("BailBondsmanId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("SerialNumber")
                        .IsRequired();

                    b.HasKey("RecoveryAgentId");

                    b.HasIndex("AddressId");

                    b.HasIndex("BailBondsmanId");

                    b.ToTable("RecoveryAgents");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Bhoba.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int>("AddressId");

                    b.Property<int>("ApplicationUserRoleId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasIndex("AddressId");

                    b.HasIndex("ApplicationUserRoleId");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new { Id = "dd05417a-60e4-4f5a-a37d-361b14ea50ef", AccessFailedCount = 0, ConcurrencyStamp = "e73f1d6a-67ef-4ca5-b7bd-68af5d0839dc", Email = "admin@admin.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "ADMIN@ADMIN.COM", NormalizedUserName = "ADMIN@ADMIN.COM", PasswordHash = "AQAAAAEAACcQAAAAEDdoJ49SOE/iOpW7wVuZmJ5jHbSqYKthIN3FnKLbyu5xSIoK58xANCcKcpzLi6XPcg==", PhoneNumberConfirmed = false, SecurityStamp = "5aa484b7-4666-49e1-949b-6c3fa8b9e5d0", TwoFactorEnabled = false, UserName = "admin@admin.com", AddressId = 1, ApplicationUserRoleId = 1, FirstName = "admin", LastName = "admin" }
                    );
                });

            modelBuilder.Entity("Bhoba.Models.BailBondsman", b =>
                {
                    b.HasOne("Bhoba.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bhoba.Models.FelonAddress", b =>
                {
                    b.HasOne("Bhoba.Models.Address", "Address")
                        .WithMany("FelonAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bhoba.Models.Felon", "Felon")
                        .WithMany("FelonAddresses")
                        .HasForeignKey("FelonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bhoba.Models.RecoveryAgent", b =>
                {
                    b.HasOne("Bhoba.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bhoba.Models.BailBondsman")
                        .WithMany("RecoveryAgents")
                        .HasForeignKey("BailBondsmanId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bhoba.Models.ApplicationUser", b =>
                {
                    b.HasOne("Bhoba.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bhoba.Models.ApplicationUserRole", "Role")
                        .WithMany()
                        .HasForeignKey("ApplicationUserRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}