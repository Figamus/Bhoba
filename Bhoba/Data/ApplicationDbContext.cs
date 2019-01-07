using System;
using System.Collections.Generic;
using System.Text;
using Bhoba.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bhoba.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BailBondsman> BailBondsmans { get; set; }
        public DbSet<Felon> Felons { get; set; }
        public DbSet<FelonBounty> FelonBounties { get; set; }
        public DbSet<RecoveryAgent> RecoveryAgents { get; set; }
        public DbSet<FelonAddress> FelonAddresses { get; set; }
        public DbSet<ApplicationUserRole> ApplicatonUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole()
                {
                    ApplicationUserRoleId = 1,
                    RoleName = "Admin"
                },
                new ApplicationUserRole()
                {
                    ApplicationUserRoleId = 2,
                    RoleName = "Recovery Agent"
                },
                new ApplicationUserRole()
                {
                    ApplicationUserRoleId = 3,
                    RoleName = "Bail Bondsman"
                }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address()
                {
                    AddressId = 1,
                    StreetAddress= "3001 Alan Dr.",
                    City = "Spring Hill",
                    State = "TN",
                    ZipCode = "37174",
                    Latitude = 35.7386591f,
                    Longitude = -86.90933509999999f
                },
                new Address()
                {
                    AddressId = 2,
                    StreetAddress = "500 Interstate Blvd.",
                    City = "Nashville",
                    State = "TN",
                    ZipCode = "37210",
                    Latitude = 36.132866f,
                    Longitude = -86.7563141f
                },
                new Address()
                {
                    AddressId = 3,
                    StreetAddress = "4900 Port Royal Rd.",
                    City = "Spring Hill",
                    State = "TN",
                    ZipCode = "37174",
                    Latitude = 35.7386591f,
                    Longitude = -86.90933509999999f
                },
                new Address()
                {
                    AddressId = 4,
                    StreetAddress = "627 Gallatin Pike S",
                    City = "Madison",
                    State = "TN",
                    ZipCode = "37115",
                    Latitude = 36.2566023f,
                    Longitude = -86.7131316f
                },
                new Address()
                {
                    AddressId = 5,
                    StreetAddress = "1556 W McEwen Dr.",
                    City = "Franklin",
                    State = "TN",
                    ZipCode = "37067",
                    Latitude = 35.9349765f,
                    Longitude = -86.82579f
                },
                new Address()
                {
                    AddressId = 6,
                    StreetAddress = "1556 W McEwen Dr.",
                    City = "Franklin",
                    State = "TN",
                    ZipCode = "37067",
                    Latitude = 35.9349765f,
                    Longitude = -86.82579f
                },
                new Address()
                {
                    AddressId = 7,
                    StreetAddress = "1556 W McEwen Dr.",
                    City = "Franklin",
                    State = "TN",
                    ZipCode = "37067",
                    Latitude = 35.9349765f,
                    Longitude = -86.82579f
                }
            );

            modelBuilder.Entity<BailBondsman>().HasData(
                new BailBondsman()
                {
                    BailBondsmanId = 1,
                    Name = "Hunt You Down Bailbonds, LLC",
                    AddressId = 2,
                },
                new BailBondsman()
                {
                    BailBondsmanId = 2,
                    Name = "Music City Bailbonds, LLC",
                    AddressId = 3,
                },
                new BailBondsman()
                {
                    BailBondsmanId = 3,
                    Name = "You Screwed Up Bailbonds, LLC",
                    AddressId = 4,
                }
            );

            modelBuilder.Entity<Felon>().HasData(
                new Felon()
                {
                    FelonId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1917, 4, 1),
                    Alias = "Johnny Boy"
                },
                new Felon()
                {
                    FelonId = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1987, 3, 18),
                    Alias = "Miss JD"
                },
                new Felon()
                {
                    FelonId = 3,
                    FirstName = "James",
                    LastName = "Bobson",
                    DateOfBirth = new DateTime(1997, 1, 22),
                    Alias = "JimBob"
                }
            );

            modelBuilder.Entity<FelonAddress>().HasData(
                new FelonAddress()
                {
                    FelonAddressId = 1,
                    FelonId = 1,
                    AddressId = 5,
                },
                new FelonAddress()
                {
                    FelonAddressId = 2,
                    FelonId = 2,
                    AddressId = 6,
                },
                new FelonAddress()
                {
                    FelonAddressId = 3,
                    FelonId = 3,
                    AddressId = 7,
                }
            );

            modelBuilder.Entity<FelonBounty>().HasData(
                new FelonBounty()
                {
                    FelonBountyId = 1,
                    BailBondsmanId = 1,
                    FelonId = 1,
                    PoliceReportNumber = "S-0079-AJ007",
                    CrimeType = "Indecent Exposure",
                    Description = "Public exposure to blind people",
                    BountyAmount = 10000.00,
                    BondClosed = false
                },
                new FelonBounty()
                {
                    FelonBountyId = 2,
                    BailBondsmanId = 2,
                    FelonId = 2,
                    PoliceReportNumber = "B-0179-BB345",
                    CrimeType = "Traffic Violation",
                    Description = "Unpaid parking violations in excess of 1,000 USD",
                    BountyAmount = 8000.00,
                    BondClosed = false
                },
                new FelonBounty()
                {
                    FelonBountyId = 3,
                    BailBondsmanId = 3,
                    FelonId = 1,
                    PoliceReportNumber = "X-0325-PS846",
                    CrimeType = "Breaking & Entering",
                    Description = "Unlawful entry into a private residence.",
                    BountyAmount = 6000.00,
                    BondClosed = true
                }
            );

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                AddressId = 1,
                ApplicationUserRoleId = 1,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);
        }
    }
}