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
        public DbSet <FinwireAgency> FinwireAgencies { get; set; }
        public DbSet <FinwireFilter> FinwireFilters { get; set; }
        public DbSet<TittleSlug> TittleSlugs { get; set; }

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

            FiltersSeeding(modelBuilder);
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
    }
}
