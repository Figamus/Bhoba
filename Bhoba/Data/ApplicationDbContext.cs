using System;
using System.Collections.Generic;
using System.Text;
using Bhoba.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bhoba.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BailBondsman> BailBondsmans { get; set; }
        public DbSet<Felon> Felons { get; set; }
        public DbSet<FelonBounty> FelonBounties { get; set; }
        public DbSet<RecoveryAgent> RecoveryAgents { get; set; }
        public DbSet<FelonAddress> FelonAddresses { get; set; }
    }
}