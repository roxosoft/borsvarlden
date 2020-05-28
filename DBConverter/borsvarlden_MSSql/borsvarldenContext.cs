using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class borsvarldenContext : DbContext
    {
        public borsvarldenContext()
        {
        }

        public borsvarldenContext(DbContextOptions<borsvarldenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AggregatedCounter> AggregatedCounter { get; set; }
        public virtual DbSet<ApplicationUsers> ApplicationUsers { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<FinwireAgencies> FinwireAgencies { get; set; }
        public virtual DbSet<FinwireCompanies> FinwireCompanies { get; set; }
        public virtual DbSet<FinwireFilters> FinwireFilters { get; set; }
        public virtual DbSet<FinwireNew2FinwireCompany> FinwireNew2FinwireCompany { get; set; }
        public virtual DbSet<FinwireNew2FirnwireSocialTag> FinwireNew2FirnwireSocialTag { get; set; }
        public virtual DbSet<FinwireNews> FinwireNews { get; set; }
        public virtual DbSet<FinwireSocialTags> FinwireSocialTags { get; set; }
        public virtual DbSet<Hash> Hash { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobParameter> JobParameter { get; set; }
        public virtual DbSet<JobQueue> JobQueue { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<NewsMetas> NewsMetas { get; set; }
        public virtual DbSet<Schema> Schema { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<State> State { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=borsvarlden;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AggregatedCounter>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_HangFire_CounterAggregated");

                entity.ToTable("AggregatedCounter", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_AggregatedCounter_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<ApplicationUsers>(entity =>
            {
                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Counter", "HangFire");

                entity.HasIndex(e => e.Key)
                    .HasName("CX_HangFire_Counter")
                    .IsClustered();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<FinwireCompanies>(entity =>
            {
                entity.HasIndex(e => e.FinwireAgencyId);

                entity.HasOne(d => d.FinwireAgency)
                    .WithMany(p => p.FinwireCompanies)
                    .HasForeignKey(d => d.FinwireAgencyId);
            });

            modelBuilder.Entity<FinwireNew2FinwireCompany>(entity =>
            {
                entity.HasKey(e => new { e.FinwireNewId, e.FinwareCompanyId });

                entity.HasIndex(e => e.FinwareCompanyId);

                entity.HasOne(d => d.FinwareCompany)
                    .WithMany(p => p.FinwireNew2FinwireCompany)
                    .HasForeignKey(d => d.FinwareCompanyId);

                entity.HasOne(d => d.FinwireNew)
                    .WithMany(p => p.FinwireNew2FinwireCompany)
                    .HasForeignKey(d => d.FinwireNewId);
            });

            modelBuilder.Entity<FinwireNew2FirnwireSocialTag>(entity =>
            {
                entity.HasKey(e => new { e.FinwireSocialTagId, e.FinwireNewId });

                entity.HasIndex(e => e.FinwireNewId);

                entity.HasOne(d => d.FinwireNew)
                    .WithMany(p => p.FinwireNew2FirnwireSocialTag)
                    .HasForeignKey(d => d.FinwireNewId);

                entity.HasOne(d => d.FinwireSocialTag)
                    .WithMany(p => p.FinwireNew2FirnwireSocialTag)
                    .HasForeignKey(d => d.FinwireSocialTagId);
            });

            modelBuilder.Entity<FinwireNews>(entity =>
            {
                entity.HasIndex(e => e.FinwireAgencyId);

                entity.Property(e => e.Date).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.DateModified).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.FinautoPassed)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.FinautoPublished)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsAdvertising)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsConvertedFromMySql)
                    .IsRequired()
                    .HasColumnName("IsConvertedFromMySQL")
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.FinwireAgency)
                    .WithMany(p => p.FinwireNews)
                    .HasForeignKey(d => d.FinwireAgencyId);
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Field })
                    .HasName("PK_HangFire_Hash");

                entity.ToTable("Hash", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_Hash_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(100);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "HangFire");

                entity.HasIndex(e => e.StateName)
                    .HasName("IX_HangFire_Job_StateName")
                    .HasFilter("([StateName] IS NOT NULL)");

                entity.HasIndex(e => new { e.StateName, e.ExpireAt })
                    .HasName("IX_HangFire_Job_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Arguments).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.InvocationData).IsRequired();

                entity.Property(e => e.StateName).HasMaxLength(20);
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Name })
                    .HasName("PK_HangFire_JobParameter");

                entity.ToTable("JobParameter", "HangFire");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameter)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobQueue>(entity =>
            {
                entity.HasKey(e => new { e.Queue, e.Id })
                    .HasName("PK_HangFire_JobQueue");

                entity.ToTable("JobQueue", "HangFire");

                entity.Property(e => e.Queue).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FetchedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Id })
                    .HasName("PK_HangFire_List");

                entity.ToTable("List", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_List_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<NewsMetas>(entity =>
            {
                entity.HasIndex(e => e.FinwireNewId);

                entity.HasOne(d => d.FinwireNew)
                    .WithMany(p => p.NewsMetas)
                    .HasForeignKey(d => d.FinwireNewId);
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK_HangFire_Schema");

                entity.ToTable("Schema", "HangFire");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("Server", "HangFire");

                entity.HasIndex(e => e.LastHeartbeat)
                    .HasName("IX_HangFire_Server_LastHeartbeat");

                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Value })
                    .HasName("PK_HangFire_Set");

                entity.ToTable("Set", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_Set_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.HasIndex(e => new { e.Key, e.Score })
                    .HasName("IX_HangFire_Set_Score");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(256);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Id })
                    .HasName("PK_HangFire_State");

                entity.ToTable("State", "HangFire");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
