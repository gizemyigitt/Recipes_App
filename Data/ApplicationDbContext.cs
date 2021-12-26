using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebSite.Models;

namespace WebSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Tatli> Tatli { get; set; }

        public DbSet<Kategori> Kategori { get; set; }

        public DbSet<DunyaMutfak> DunyaMutfak { get; set; }

        public DbSet<WebSite.Models.Malzeme> Malzeme { get; set; }

        public DbSet<WebSite.Models.TatliMalzeme> TatliMalzeme { get; set; }

        public DbSet<WebSite.Models.Tarifler> Tarifler { get; set; }
    }
}
