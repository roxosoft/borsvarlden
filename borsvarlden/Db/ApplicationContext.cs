using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using borsvarlden.Models;

namespace borsvarlden.Db
{
    
    public class ApplicationContext :DbContext
    {
        public DbSet <FinwireNew> FinwireNews { get;set; }
        public DbSet <FinwireCompany> FinwireCompanies { get; set; }
        public DbSet <FinwireSocialTag> FinwireSocialTags { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinwireNew2FinwireCompany>()
                .HasKey(t => new {t.FinwireNewId, t.FinwareCompanyId});

            modelBuilder.Entity<FinwireNew2FinwireCompany>()
                .HasOne(c => c.FinwireCompany)
                .WithMany(p => p.FinwireNew2FinwireCompanies)
                .HasForeignKey(p => p.FinwareCompanyId);

            modelBuilder.Entity<FinwireNew2FinwireCompany>()
                .HasOne(c => c.FinwireNew)
                .WithMany(p => p.FinwireNew2FinwireCompanies)
                .HasForeignKey(p => p.FinwareCompanyId);

            modelBuilder.Entity<FinwireNew2FirnwireSocialTag>()
                .HasKey(t => new {t.FinwireSocialTagId, t.FinwireNewId});


            modelBuilder.Entity<FinwireNew2FirnwireSocialTag>()
                .HasOne(c => c.FinwireSocialTag)
                .WithMany(p => p.FinwireNew2FirnwireSocialTags)
                .HasForeignKey(p => p.FinwireSocialTagId);

            modelBuilder.Entity<FinwireNew2FirnwireSocialTag>()
                .HasOne(c => c.FinwireNew)
                .WithMany(p => p.FinwireNew2FirnwireSocialTags)
                .HasForeignKey(p => p.FinwireNewId);

        }
    }
}
