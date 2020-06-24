﻿using Microsoft.EntityFrameworkCore;
using borsvarlden.Models;

namespace borsvarlden.Db
{
    public class ApplicationContext :DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet <FinwireNew> FinwireNews { get;set; }
        public DbSet <FinwireCompany> FinwireCompanies { get; set; }
        public DbSet <FinwireSocialTag> FinwireSocialTags { get; set; }
        public DbSet <FinwireAgency> FinwireAgencies { get; set; }
        public DbSet <FinwireFilter> FinwireFilters { get; set; }
        public DbSet <NewsMeta> NewsMetas { get; set; }
        public DbSet<FinwireXmlNews> FinwireXmlNews { get; set; }
        public virtual DbSet<FinwireNew2FinwireCompany> FinwireNew2FinwireCompany { get; set; }
        public virtual DbSet<FinwireNew2FirnwireSocialTag> FinwireNew2FirnwireSocialTag { get; set; }

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
                .HasForeignKey(p => p.FinwireNewId);

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

            modelBuilder.Entity<FinwireNew>()
                .HasIndex(x=>x.Slug);

            modelBuilder.Entity<FinwireNew>()
                .HasIndex(x => x.Guid);

            modelBuilder.Entity<FinwireNew>()
                .HasIndex(x => x.Date)
                .HasName("IndexDate");

            modelBuilder.Entity<FinwireNew>()
                .HasIndex(x => x.ActualDeadLine)
                .HasName("IndexActualDeadLine");

            modelBuilder.Entity<FinwireNew>()
                .HasIndex(x => x.PrioDeadLine)
                .HasName("IndexPrioDeadLine");

            FiltersSeeding(modelBuilder);

            UsersSeeding(modelBuilder);
        }

        private void FiltersSeeding(ModelBuilder modelBuilder)
        {
            var i = 1;

            modelBuilder.Entity<FinwireFilter>().HasData(
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._01_TitleWhitelist, Value = "Stockholm Bullets" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._01_TitleWhitelist, Value = "Stocks in Play" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._01_TitleWhitelist, Value = "Dagens aktierekommendationer i översikt" },

                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._02_TitleBlackList, Value = "(uppdatering)" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._02_TitleBlackList, Value = "(uppdaterad)" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._02_TitleBlackList, Value = "(Oms)" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._02_TitleBlackList, Value = "(forts)" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._02_TitleBlackList, Value = "(omsändning)" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._02_TitleBlackList, Value = "(r)" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._02_TitleBlackList, Value = "(rättelse)" },

                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "analytics" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "automotive" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "betting" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "biometrics" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "commodities" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "crowdfunding" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "cryptocurrency" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "dividend" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "funding" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "gaming" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "ipo" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "macro" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "share" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "stockholmbullets" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._03_TitleSocialTags, Value = "tech" },

                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._04_FilterComplanies, Value = "avanza" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._04_FilterComplanies, Value = "nordent" },
                new FinwireFilter { Id = i++, FinwireFilterType = EnumFinwireFilterTypes._04_FilterComplanies, Value = "hm" }
            );
        }

        private void UsersSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = 1, UserName = "admin", PasswordHash = "21232F297A57A5A743894A0E4A801FC3" } // admin:admin
            );
        }
    }
}
