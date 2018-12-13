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
                    RoleName = "Bail Bondsman"
                },
                new ApplicationUserRole()
                {
                    ApplicationUserRoleId = 3,
                    RoleName = "Recovery Agent"
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