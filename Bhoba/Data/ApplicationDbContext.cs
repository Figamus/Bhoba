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
                    StreetAddress= "123 Admin Way",
                    City = "Everywhere",
                    State = "XX",
                    ZipCode = "12345"
                },
                new Address()
                {
                    AddressId = 2,
                    StreetAddress = "223 Admin Way",
                    City = "Everywhere2",
                    State = "XX",
                    ZipCode = "12345"
                },
                new Address()
                {
                    AddressId = 3,
                    StreetAddress = "323 Admin Way",
                    City = "Everywhere3",
                    State = "XX",
                    ZipCode = "12345"
                },
                new Address()
                {
                    AddressId = 4,
                    StreetAddress = "423 Admin Way",
                    City = "Everywhere4",
                    State = "XX",
                    ZipCode = "12345"
                },
                new Address()
                {
                    AddressId = 5,
                    StreetAddress = "523 Admin Way",
                    City = "Everywhere5",
                    State = "XX",
                    ZipCode = "12345"
                },
                new Address()
                {
                    AddressId = 6,
                    StreetAddress = "623 Admin Way",
                    City = "Everywhere6",
                    State = "XX",
                    ZipCode = "12345"
                },
                new Address()
                {
                    AddressId = 7,
                    StreetAddress = "723 Admin Way",
                    City = "Everywhere7",
                    State = "XX",
                    ZipCode = "12345"
                },
                new Address()
                {
                    AddressId = 8,
                    StreetAddress = "823 Admin Way",
                    City = "Everywhere8",
                    State = "XX",
                    ZipCode = "12345"
                },
                new Address()
                {
                    AddressId = 9,
                    StreetAddress = "923 Admin Way",
                    City = "Everywhere9",
                    State = "XX",
                    ZipCode = "12345"
                },
                new Address()
                {
                    AddressId = 10,
                    StreetAddress= "1023 Admin Way",
                    City = "Everywhere10",
                    State = "XX",
                    ZipCode = "12345"
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
                    Name = "You Done Fucked Up Bailbonds, LLC",
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
                    Alias = "Bobo"
                },
                new Felon()
                {
                    FelonId = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1987, 3, 18),
                    Alias = "Bitch"
                },
                new Felon()
                {
                    FelonId = 3,
                    FirstName = "Jim",
                    LastName = "Bob",
                    DateOfBirth = new DateTime(1997, 1, 22),
                    Alias = "James"
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