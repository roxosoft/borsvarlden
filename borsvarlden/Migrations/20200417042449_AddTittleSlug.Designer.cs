﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using borsvarlden.Db;

namespace borsvarlden.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200417042449_AddTittleSlug")]
    partial class AddTittleSlug
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("borsvarlden.Models.FinwireAgency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agency")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FinwireAgencies");
                });

            modelBuilder.Entity("borsvarlden.Models.FinwireCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FinwireAgencyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinwireAgencyId");

                    b.ToTable("FinwireCompanies");
                });

            modelBuilder.Entity("borsvarlden.Models.FinwireFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("FinwireFilterType")
                        .HasColumnType("smallint");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FinwireFilters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FinwireFilterType = (short)1,
                            Value = "Stockholm Bullets"
                        },
                        new
                        {
                            Id = 2,
                            FinwireFilterType = (short)1,
                            Value = "Stocks in Play"
                        },
                        new
                        {
                            Id = 3,
                            FinwireFilterType = (short)1,
                            Value = "Dagens aktierekommendationer i översikt"
                        },
                        new
                        {
                            Id = 4,
                            FinwireFilterType = (short)2,
                            Value = "(uppdatering)"
                        },
                        new
                        {
                            Id = 5,
                            FinwireFilterType = (short)2,
                            Value = "(uppdaterad)"
                        },
                        new
                        {
                            Id = 6,
                            FinwireFilterType = (short)2,
                            Value = "(Oms)"
                        },
                        new
                        {
                            Id = 7,
                            FinwireFilterType = (short)2,
                            Value = "(forts)"
                        },
                        new
                        {
                            Id = 8,
                            FinwireFilterType = (short)2,
                            Value = "(omsändning)"
                        },
                        new
                        {
                            Id = 9,
                            FinwireFilterType = (short)2,
                            Value = "(r)"
                        },
                        new
                        {
                            Id = 10,
                            FinwireFilterType = (short)2,
                            Value = "(rättelse)"
                        },
                        new
                        {
                            Id = 11,
                            FinwireFilterType = (short)3,
                            Value = "analytics"
                        },
                        new
                        {
                            Id = 12,
                            FinwireFilterType = (short)3,
                            Value = "automotive"
                        },
                        new
                        {
                            Id = 13,
                            FinwireFilterType = (short)3,
                            Value = "betting"
                        },
                        new
                        {
                            Id = 14,
                            FinwireFilterType = (short)3,
                            Value = "biometrics"
                        },
                        new
                        {
                            Id = 15,
                            FinwireFilterType = (short)3,
                            Value = "commodities"
                        },
                        new
                        {
                            Id = 16,
                            FinwireFilterType = (short)3,
                            Value = "crowdfunding"
                        },
                        new
                        {
                            Id = 17,
                            FinwireFilterType = (short)3,
                            Value = "cryptocurrency"
                        },
                        new
                        {
                            Id = 18,
                            FinwireFilterType = (short)3,
                            Value = "dividend"
                        },
                        new
                        {
                            Id = 19,
                            FinwireFilterType = (short)3,
                            Value = "funding"
                        },
                        new
                        {
                            Id = 20,
                            FinwireFilterType = (short)3,
                            Value = "gaming"
                        },
                        new
                        {
                            Id = 21,
                            FinwireFilterType = (short)3,
                            Value = "ipo"
                        },
                        new
                        {
                            Id = 22,
                            FinwireFilterType = (short)3,
                            Value = "macro"
                        },
                        new
                        {
                            Id = 23,
                            FinwireFilterType = (short)3,
                            Value = "share"
                        },
                        new
                        {
                            Id = 24,
                            FinwireFilterType = (short)3,
                            Value = "stockholmbullets"
                        },
                        new
                        {
                            Id = 25,
                            FinwireFilterType = (short)3,
                            Value = "tech"
                        },
                        new
                        {
                            Id = 26,
                            FinwireFilterType = (short)4,
                            Value = "avanza"
                        },
                        new
                        {
                            Id = 27,
                            FinwireFilterType = (short)4,
                            Value = "nordent"
                        },
                        new
                        {
                            Id = 28,
                            FinwireFilterType = (short)4,
                            Value = "hm"
                        });
                });

            modelBuilder.Entity("borsvarlden.Models.FinwireNew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("FinautoPassed")
                        .HasColumnType("bit");

                    b.Property<bool>("FinautoPublished")
                        .HasColumnType("bit");

                    b.Property<int?>("FinwireAgencyId")
                        .HasColumnType("int");

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageRelativeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathRelative")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TittleSlugId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinwireAgencyId");

                    b.HasIndex("TittleSlugId");

                    b.ToTable("FinwireNews");
                });

            modelBuilder.Entity("borsvarlden.Models.FinwireNew2FinwireCompany", b =>
                {
                    b.Property<int>("FinwireNewId")
                        .HasColumnType("int");

                    b.Property<int>("FinwareCompanyId")
                        .HasColumnType("int");

                    b.HasKey("FinwireNewId", "FinwareCompanyId");

                    b.HasIndex("FinwareCompanyId");

                    b.ToTable("FinwireNew2FinwireCompany");
                });

            modelBuilder.Entity("borsvarlden.Models.FinwireNew2FirnwireSocialTag", b =>
                {
                    b.Property<int>("FinwireSocialTagId")
                        .HasColumnType("int");

                    b.Property<int>("FinwireNewId")
                        .HasColumnType("int");

                    b.HasKey("FinwireSocialTagId", "FinwireNewId");

                    b.HasIndex("FinwireNewId");

                    b.ToTable("FinwireNew2FirnwireSocialTag");
                });

            modelBuilder.Entity("borsvarlden.Models.FinwireSocialTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FinwireSocialTags");
                });

            modelBuilder.Entity("borsvarlden.Models.TittleSlug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TittleSlugs");
                });

            modelBuilder.Entity("borsvarlden.Models.FinwireCompany", b =>
                {
                    b.HasOne("borsvarlden.Models.FinwireAgency", null)
                        .WithMany("FinwireCompanies")
                        .HasForeignKey("FinwireAgencyId");
                });

            modelBuilder.Entity("borsvarlden.Models.FinwireNew", b =>
                {
                    b.HasOne("borsvarlden.Models.FinwireAgency", "FinwireAgency")
                        .WithMany()
                        .HasForeignKey("FinwireAgencyId");

                    b.HasOne("borsvarlden.Models.TittleSlug", "TittleSlug")
                        .WithMany()
                        .HasForeignKey("TittleSlugId");
                });

            modelBuilder.Entity("borsvarlden.Models.FinwireNew2FinwireCompany", b =>
                {
                    b.HasOne("borsvarlden.Models.FinwireCompany", "FinwireCompany")
                        .WithMany("FinwireNew2FinwireCompanies")
                        .HasForeignKey("FinwareCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("borsvarlden.Models.FinwireNew", "FinwireNew")
                        .WithMany("FinwireNew2FinwireCompanies")
                        .HasForeignKey("FinwireNewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("borsvarlden.Models.FinwireNew2FirnwireSocialTag", b =>
                {
                    b.HasOne("borsvarlden.Models.FinwireNew", "FinwireNew")
                        .WithMany("FinwireNew2FirnwireSocialTags")
                        .HasForeignKey("FinwireNewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("borsvarlden.Models.FinwireSocialTag", "FinwireSocialTag")
                        .WithMany("FinwireNew2FirnwireSocialTags")
                        .HasForeignKey("FinwireSocialTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
