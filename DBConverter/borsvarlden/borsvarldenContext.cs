using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBConverter.borsvarlden
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

        public virtual DbSet<WpCommentmeta> WpCommentmeta { get; set; }
        public virtual DbSet<WpComments> WpComments { get; set; }
        public virtual DbSet<WpFinwireNews> WpFinwireNews { get; set; }
        public virtual DbSet<WpFinwireNewsCompanies> WpFinwireNewsCompanies { get; set; }
        public virtual DbSet<WpFinwireNewsTags> WpFinwireNewsTags { get; set; }
        public virtual DbSet<WpFinwireTags> WpFinwireTags { get; set; }
        public virtual DbSet<WpIclContentStatus> WpIclContentStatus { get; set; }
        public virtual DbSet<WpIclCoreStatus> WpIclCoreStatus { get; set; }
        public virtual DbSet<WpIclFlags> WpIclFlags { get; set; }
        public virtual DbSet<WpIclLanguages> WpIclLanguages { get; set; }
        public virtual DbSet<WpIclLanguagesTranslations> WpIclLanguagesTranslations { get; set; }
        public virtual DbSet<WpIclLocaleMap> WpIclLocaleMap { get; set; }
        public virtual DbSet<WpIclMessageStatus> WpIclMessageStatus { get; set; }
        public virtual DbSet<WpIclMoFilesDomains> WpIclMoFilesDomains { get; set; }
        public virtual DbSet<WpIclNode> WpIclNode { get; set; }
        public virtual DbSet<WpIclReminders> WpIclReminders { get; set; }
        public virtual DbSet<WpIclStringPackages> WpIclStringPackages { get; set; }
        public virtual DbSet<WpIclStringPages> WpIclStringPages { get; set; }
        public virtual DbSet<WpIclStringPositions> WpIclStringPositions { get; set; }
        public virtual DbSet<WpIclStringStatus> WpIclStringStatus { get; set; }
        public virtual DbSet<WpIclStringTranslations> WpIclStringTranslations { get; set; }
        public virtual DbSet<WpIclStringUrls> WpIclStringUrls { get; set; }
        public virtual DbSet<WpIclStrings> WpIclStrings { get; set; }
        public virtual DbSet<WpIclTranslate> WpIclTranslate { get; set; }
        public virtual DbSet<WpIclTranslateJob> WpIclTranslateJob { get; set; }
        public virtual DbSet<WpIclTranslationBatches> WpIclTranslationBatches { get; set; }
        public virtual DbSet<WpIclTranslationStatus> WpIclTranslationStatus { get; set; }
        public virtual DbSet<WpIclTranslations> WpIclTranslations { get; set; }
        public virtual DbSet<WpLayerslider> WpLayerslider { get; set; }
        public virtual DbSet<WpLinks> WpLinks { get; set; }
        public virtual DbSet<WpOptions> WpOptions { get; set; }
        public virtual DbSet<WpPostmeta> WpPostmeta { get; set; }
        public virtual DbSet<WpPosts> WpPosts { get; set; }
        public virtual DbSet<WpRedirection404> WpRedirection404 { get; set; }
        public virtual DbSet<WpRedirectionGroups> WpRedirectionGroups { get; set; }
        public virtual DbSet<WpRedirectionItems> WpRedirectionItems { get; set; }
        public virtual DbSet<WpRedirectionLogs> WpRedirectionLogs { get; set; }
        public virtual DbSet<WpRevsliderCss> WpRevsliderCss { get; set; }
        public virtual DbSet<WpRevsliderCssBkp> WpRevsliderCssBkp { get; set; }
        public virtual DbSet<WpRevsliderLayerAnimations> WpRevsliderLayerAnimations { get; set; }
        public virtual DbSet<WpRevsliderLayerAnimationsBkp> WpRevsliderLayerAnimationsBkp { get; set; }
        public virtual DbSet<WpRevsliderNavigations> WpRevsliderNavigations { get; set; }
        public virtual DbSet<WpRevsliderNavigationsBkp> WpRevsliderNavigationsBkp { get; set; }
        public virtual DbSet<WpRevsliderSliders> WpRevsliderSliders { get; set; }
        public virtual DbSet<WpRevsliderSlidersBkp> WpRevsliderSlidersBkp { get; set; }
        public virtual DbSet<WpRevsliderSlides> WpRevsliderSlides { get; set; }
        public virtual DbSet<WpRevsliderSlidesBkp> WpRevsliderSlidesBkp { get; set; }
        public virtual DbSet<WpRevsliderStaticSlides> WpRevsliderStaticSlides { get; set; }
        public virtual DbSet<WpRevsliderStaticSlidesBkp> WpRevsliderStaticSlidesBkp { get; set; }
        public virtual DbSet<WpTermRelationships> WpTermRelationships { get; set; }
        public virtual DbSet<WpTermTaxonomy> WpTermTaxonomy { get; set; }
        public virtual DbSet<WpTermmeta> WpTermmeta { get; set; }
        public virtual DbSet<WpTerms> WpTerms { get; set; }
        public virtual DbSet<WpTopTen> WpTopTen { get; set; }
        public virtual DbSet<WpTopTenDaily> WpTopTenDaily { get; set; }
        public virtual DbSet<WpUsermeta> WpUsermeta { get; set; }
        public virtual DbSet<WpUsers> WpUsers { get; set; }
        public virtual DbSet<WpWfblockediplog> WpWfblockediplog { get; set; }
        public virtual DbSet<WpWfblocks7> WpWfblocks7 { get; set; }
        public virtual DbSet<WpWfconfig> WpWfconfig { get; set; }
        public virtual DbSet<WpWfcrawlers> WpWfcrawlers { get; set; }
        public virtual DbSet<WpWffilechanges> WpWffilechanges { get; set; }
        public virtual DbSet<WpWffilemods> WpWffilemods { get; set; }
        public virtual DbSet<WpWfhits> WpWfhits { get; set; }
        public virtual DbSet<WpWfhoover> WpWfhoover { get; set; }
        public virtual DbSet<WpWfissues> WpWfissues { get; set; }
        public virtual DbSet<WpWfknownfilelist> WpWfknownfilelist { get; set; }
        public virtual DbSet<WpWflivetraffichuman> WpWflivetraffichuman { get; set; }
        public virtual DbSet<WpWflocs> WpWflocs { get; set; }
        public virtual DbSet<WpWflogins> WpWflogins { get; set; }
        public virtual DbSet<WpWfls2faSecrets> WpWfls2faSecrets { get; set; }
        public virtual DbSet<WpWflsSettings> WpWflsSettings { get; set; }
        public virtual DbSet<WpWfnotifications> WpWfnotifications { get; set; }
        public virtual DbSet<WpWfpendingissues> WpWfpendingissues { get; set; }
        public virtual DbSet<WpWfreversecache> WpWfreversecache { get; set; }
        public virtual DbSet<WpWfsnipcache> WpWfsnipcache { get; set; }
        public virtual DbSet<WpWfstatus> WpWfstatus { get; set; }
        public virtual DbSet<WpWftrafficrates> WpWftrafficrates { get; set; }
        public virtual DbSet<WpWpeditorSettings> WpWpeditorSettings { get; set; }
        public virtual DbSet<WpXyzIhsShortCode> WpXyzIhsShortCode { get; set; }
        public virtual DbSet<WpYoastSeoLinks> WpYoastSeoLinks { get; set; }
        public virtual DbSet<WpYoastSeoMeta> WpYoastSeoMeta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=12345;database=borsvarlden");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WpCommentmeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_commentmeta");

                entity.HasIndex(e => e.CommentId)
                    .HasName("comment_id");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.Property(e => e.MetaId)
                    .HasColumnName("meta_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpComments>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_comments");

                entity.HasIndex(e => e.CommentAuthorEmail)
                    .HasName("comment_author_email");

                entity.HasIndex(e => e.CommentDateGmt)
                    .HasName("comment_date_gmt");

                entity.HasIndex(e => e.CommentParent)
                    .HasName("comment_parent");

                entity.HasIndex(e => e.CommentPostId)
                    .HasName("comment_post_ID");

                entity.HasIndex(e => new { e.CommentApproved, e.CommentDateGmt })
                    .HasName("comment_approved_date_gmt");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_ID")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CommentAgent)
                    .IsRequired()
                    .HasColumnName("comment_agent")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentApproved)
                    .IsRequired()
                    .HasColumnName("comment_approved")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CommentAuthor)
                    .IsRequired()
                    .HasColumnName("comment_author")
                    .HasColumnType("tinytext");

                entity.Property(e => e.CommentAuthorEmail)
                    .IsRequired()
                    .HasColumnName("comment_author_email")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentAuthorIp)
                    .IsRequired()
                    .HasColumnName("comment_author_IP")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentAuthorUrl)
                    .IsRequired()
                    .HasColumnName("comment_author_url")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasColumnName("comment_content");

                entity.Property(e => e.CommentDate)
                    .HasColumnName("comment_date")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.CommentDateGmt)
                    .HasColumnName("comment_date_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.CommentKarma).HasColumnName("comment_karma");

                entity.Property(e => e.CommentParent)
                    .HasColumnName("comment_parent")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CommentPostId)
                    .HasColumnName("comment_post_ID")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CommentType)
                    .IsRequired()
                    .HasColumnName("comment_type")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpFinwireNews>(entity =>
            {
                entity.ToTable("wp_finwire_news");

                entity.HasIndex(e => e.Guid)
                    .HasName("guid")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasColumnName("file")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.FinautoPassed)
                    .HasColumnName("finauto_passed")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.FinautoPublished)
                    .HasColumnName("finauto_published")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("guid")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");
            });

            modelBuilder.Entity<WpFinwireNewsCompanies>(entity =>
            {
                entity.HasKey(e => new { e.NewsId, e.TermId })
                    .HasName("PRIMARY");

                entity.ToTable("wp_finwire_news_companies");

                entity.HasIndex(e => e.TermId)
                    .HasName("term_id");

                entity.Property(e => e.NewsId)
                    .HasColumnName("news_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpFinwireNewsTags>(entity =>
            {
                entity.HasKey(e => new { e.NewsId, e.TermId })
                    .HasName("PRIMARY");

                entity.ToTable("wp_finwire_news_tags");

                entity.HasIndex(e => e.TermId)
                    .HasName("term_id");

                entity.Property(e => e.NewsId)
                    .HasColumnName("news_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpFinwireTags>(entity =>
            {
                entity.ToTable("wp_finwire_tags");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpIclContentStatus>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PRIMARY");

                entity.ToTable("wp_icl_content_status");

                entity.HasIndex(e => e.Nid)
                    .HasName("nid");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.Md5)
                    .IsRequired()
                    .HasColumnName("md5")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Nid).HasColumnName("nid");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            });

            modelBuilder.Entity<WpIclCoreStatus>(entity =>
            {
                entity.ToTable("wp_icl_core_status");

                entity.HasIndex(e => e.Rid)
                    .HasName("rid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasColumnName("module")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasColumnName("origin")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasColumnName("target")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TpRevision)
                    .HasColumnName("tp_revision")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TsStatus).HasColumnName("ts_status");
            });

            modelBuilder.Entity<WpIclFlags>(entity =>
            {
                entity.ToTable("wp_icl_flags");

                entity.HasIndex(e => e.LangCode)
                    .HasName("lang_code")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Flag)
                    .IsRequired()
                    .HasColumnName("flag")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.FromTemplate).HasColumnName("from_template");

                entity.Property(e => e.LangCode)
                    .IsRequired()
                    .HasColumnName("lang_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpIclLanguages>(entity =>
            {
                entity.ToTable("wp_icl_languages");

                entity.HasIndex(e => e.Code)
                    .HasName("code")
                    .IsUnique();

                entity.HasIndex(e => e.EnglishName)
                    .HasName("english_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultLocale)
                    .HasColumnName("default_locale")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.EncodeUrl)
                    .HasColumnName("encode_url")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasColumnName("english_name")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Major).HasColumnName("major");

                entity.Property(e => e.Tag)
                    .HasColumnName("tag")
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpIclLanguagesTranslations>(entity =>
            {
                entity.ToTable("wp_icl_languages_translations");

                entity.HasIndex(e => new { e.LanguageCode, e.DisplayLanguageCode })
                    .HasName("language_code")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DisplayLanguageCode)
                    .IsRequired()
                    .HasColumnName("display_language_code")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasColumnName("language_code")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpIclLocaleMap>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_icl_locale_map");

                entity.HasIndex(e => new { e.Code, e.Locale })
                    .HasName("code")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasColumnName("locale")
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpIclMessageStatus>(entity =>
            {
                entity.ToTable("wp_icl_message_status");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("object_id");

                entity.HasIndex(e => e.Rid)
                    .HasName("rid")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.FromLanguage)
                    .IsRequired()
                    .HasColumnName("from_language")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Md5)
                    .IsRequired()
                    .HasColumnName("md5")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectId)
                    .HasColumnName("object_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.ObjectType)
                    .IsRequired()
                    .HasColumnName("object_type")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Rid)
                    .HasColumnName("rid")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ToLanguage)
                    .IsRequired()
                    .HasColumnName("to_language")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpIclMoFilesDomains>(entity =>
            {
                entity.ToTable("wp_icl_mo_files_domains");

                entity.HasIndex(e => e.FilePathMd5)
                    .HasName("file_path_md5_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ComponentId)
                    .HasColumnName("component_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentType)
                    .IsRequired()
                    .HasColumnName("component_type")
                    .HasColumnType("enum('plugin','theme','other')")
                    .HasDefaultValueSql("'other'");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasColumnName("domain")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasColumnName("file_path")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FilePathMd5)
                    .IsRequired()
                    .HasColumnName("file_path_md5")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified).HasColumnName("last_modified");

                entity.Property(e => e.NumOfStrings).HasColumnName("num_of_strings");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'not_imported'");
            });

            modelBuilder.Entity<WpIclNode>(entity =>
            {
                entity.HasKey(e => e.Nid)
                    .HasName("PRIMARY");

                entity.ToTable("wp_icl_node");

                entity.Property(e => e.Nid).HasColumnName("nid");

                entity.Property(e => e.LinksFixed).HasColumnName("links_fixed");

                entity.Property(e => e.Md5)
                    .IsRequired()
                    .HasColumnName("md5")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpIclReminders>(entity =>
            {
                entity.ToTable("wp_icl_reminders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CanDelete).HasColumnName("can_delete");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message");

                entity.Property(e => e.Show).HasColumnName("show");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url");
            });

            modelBuilder.Entity<WpIclStringPackages>(entity =>
            {
                entity.ToTable("wp_icl_string_packages");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.EditLink)
                    .IsRequired()
                    .HasColumnName("edit_link");

                entity.Property(e => e.Kind)
                    .IsRequired()
                    .HasColumnName("kind")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.KindSlug)
                    .IsRequired()
                    .HasColumnName("kind_slug")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.ViewLink)
                    .IsRequired()
                    .HasColumnName("view_link");

                entity.Property(e => e.WordCount)
                    .HasColumnName("word_count")
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpIclStringPages>(entity =>
            {
                entity.ToTable("wp_icl_string_pages");

                entity.HasIndex(e => e.StringId)
                    .HasName("string_id");

                entity.HasIndex(e => e.UrlId)
                    .HasName("string_to_url_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.StringId)
                    .HasColumnName("string_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.UrlId)
                    .HasColumnName("url_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpIclStringPositions>(entity =>
            {
                entity.ToTable("wp_icl_string_positions");

                entity.HasIndex(e => e.StringId)
                    .HasName("string_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Kind).HasColumnName("kind");

                entity.Property(e => e.PositionInPage)
                    .IsRequired()
                    .HasColumnName("position_in_page")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StringId).HasColumnName("string_id");
            });

            modelBuilder.Entity<WpIclStringStatus>(entity =>
            {
                entity.ToTable("wp_icl_string_status");

                entity.HasIndex(e => e.StringTranslationId)
                    .HasName("string_translation_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Md5)
                    .IsRequired()
                    .HasColumnName("md5")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.StringTranslationId).HasColumnName("string_translation_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<WpIclStringTranslations>(entity =>
            {
                entity.ToTable("wp_icl_string_translations");

                entity.HasIndex(e => e.Status)
                    .HasName("status");

                entity.HasIndex(e => new { e.StringId, e.Language })
                    .HasName("string_language")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.BatchId).HasColumnName("batch_id");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasColumnName("language")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoString)
                    .HasColumnName("mo_string")
                    .HasColumnType("longtext");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StringId)
                    .HasColumnName("string_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.TranslationDate)
                    .HasColumnName("translation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TranslationService)
                    .IsRequired()
                    .HasColumnName("translation_service")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TranslatorId)
                    .HasColumnName("translator_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpIclStringUrls>(entity =>
            {
                entity.ToTable("wp_icl_string_urls");

                entity.HasIndex(e => new { e.Language, e.Url })
                    .HasName("string_string_lang_url")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpIclStrings>(entity =>
            {
                entity.ToTable("wp_icl_strings");

                entity.HasIndex(e => e.Context)
                    .HasName("context");

                entity.HasIndex(e => e.DomainNameContextMd5)
                    .HasName("uc_domain_name_context_md5")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("icl_strings_name");

                entity.HasIndex(e => e.StringPackageId)
                    .HasName("string_package_id");

                entity.HasIndex(e => e.TranslationPriority)
                    .HasName("icl_strings_translation_priority");

                entity.HasIndex(e => new { e.Language, e.Context })
                    .HasName("language_context");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Context)
                    .IsRequired()
                    .HasColumnName("context")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.DomainNameContextMd5)
                    .IsRequired()
                    .HasColumnName("domain_name_context_md5")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.GettextContext)
                    .IsRequired()
                    .HasColumnName("gettext_context");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasColumnName("language")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StringPackageId)
                    .HasColumnName("string_package_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.TranslationPriority)
                    .IsRequired()
                    .HasColumnName("translation_priority")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'LINE'");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("longtext");

                entity.Property(e => e.WordCount)
                    .HasColumnName("word_count")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.WrapTag)
                    .IsRequired()
                    .HasColumnName("wrap_tag")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpIclTranslate>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PRIMARY");

                entity.ToTable("wp_icl_translate");

                entity.HasIndex(e => e.JobId)
                    .HasName("job_id");

                entity.Property(e => e.Tid)
                    .HasColumnName("tid")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.ContentId)
                    .HasColumnName("content_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.FieldData)
                    .IsRequired()
                    .HasColumnName("field_data")
                    .HasColumnType("longtext");

                entity.Property(e => e.FieldDataTranslated)
                    .IsRequired()
                    .HasColumnName("field_data_translated")
                    .HasColumnType("longtext");

                entity.Property(e => e.FieldFinished).HasColumnName("field_finished");

                entity.Property(e => e.FieldFormat)
                    .IsRequired()
                    .HasColumnName("field_format")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.FieldTranslate).HasColumnName("field_translate");

                entity.Property(e => e.FieldType)
                    .IsRequired()
                    .HasColumnName("field_type")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.FieldWrapTag)
                    .IsRequired()
                    .HasColumnName("field_wrap_tag")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<WpIclTranslateJob>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_icl_translate_job");

                entity.HasIndex(e => new { e.Rid, e.TranslatorId })
                    .HasName("rid");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CompletedDate).HasColumnName("completed_date");

                entity.Property(e => e.DeadlineDate).HasColumnName("deadline_date");

                entity.Property(e => e.EditTimestamp)
                    .HasColumnName("edit_timestamp")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Editor)
                    .HasColumnName("editor")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.EditorJobId)
                    .HasColumnName("editor_job_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("manager_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Rid)
                    .HasColumnName("rid")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.Translated)
                    .HasColumnName("translated")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.TranslatorId)
                    .HasColumnName("translator_id")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<WpIclTranslationBatches>(entity =>
            {
                entity.ToTable("wp_icl_translation_batches");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BatchName)
                    .IsRequired()
                    .HasColumnName("batch_name");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.TpId).HasColumnName("tp_id");

                entity.Property(e => e.TsUrl).HasColumnName("ts_url");
            });

            modelBuilder.Entity<WpIclTranslationStatus>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PRIMARY");

                entity.ToTable("wp_icl_translation_status");

                entity.HasIndex(e => e.TranslationId)
                    .HasName("translation_id")
                    .IsUnique();

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.BatchId).HasColumnName("batch_id");

                entity.Property(e => e.LinksFixed).HasColumnName("links_fixed");

                entity.Property(e => e.Md5)
                    .IsRequired()
                    .HasColumnName("md5")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.NeedsUpdate).HasColumnName("needs_update");

                entity.Property(e => e.Prevstate)
                    .HasColumnName("_prevstate")
                    .HasColumnType("longtext");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TpId).HasColumnName("tp_id");

                entity.Property(e => e.TpRevision)
                    .HasColumnName("tp_revision")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TranslationId).HasColumnName("translation_id");

                entity.Property(e => e.TranslationPackage)
                    .IsRequired()
                    .HasColumnName("translation_package")
                    .HasColumnType("longtext");

                entity.Property(e => e.TranslationService)
                    .IsRequired()
                    .HasColumnName("translation_service")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.TranslatorId).HasColumnName("translator_id");

                entity.Property(e => e.TsStatus).HasColumnName("ts_status");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpIclTranslations>(entity =>
            {
                entity.HasKey(e => e.TranslationId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_icl_translations");

                entity.HasIndex(e => e.Trid)
                    .HasName("trid");

                entity.HasIndex(e => new { e.ElementType, e.ElementId })
                    .HasName("el_type_id")
                    .IsUnique();

                entity.HasIndex(e => new { e.Trid, e.LanguageCode })
                    .HasName("trid_lang")
                    .IsUnique();

                entity.HasIndex(e => new { e.ElementId, e.ElementType, e.LanguageCode })
                    .HasName("id_type_language");

                entity.Property(e => e.TranslationId).HasColumnName("translation_id");

                entity.Property(e => e.ElementId).HasColumnName("element_id");

                entity.Property(e => e.ElementType)
                    .IsRequired()
                    .HasColumnName("element_type")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'post_post'");

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasColumnName("language_code")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.SourceLanguageCode)
                    .HasColumnName("source_language_code")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Trid).HasColumnName("trid");
            });

            modelBuilder.Entity<WpLayerslider>(entity =>
            {
                entity.ToTable("wp_layerslider");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author).HasColumnName("author");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.DateC).HasColumnName("date_c");

                entity.Property(e => e.DateM).HasColumnName("date_m");

                entity.Property(e => e.FlagDeleted)
                    .HasColumnName("flag_deleted")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.FlagHidden)
                    .HasColumnName("flag_hidden")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpLinks>(entity =>
            {
                entity.HasKey(e => e.LinkId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_links");

                entity.HasIndex(e => e.LinkVisible)
                    .HasName("link_visible");

                entity.Property(e => e.LinkId)
                    .HasColumnName("link_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.LinkDescription)
                    .IsRequired()
                    .HasColumnName("link_description")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkImage)
                    .IsRequired()
                    .HasColumnName("link_image")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkName)
                    .IsRequired()
                    .HasColumnName("link_name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkNotes)
                    .IsRequired()
                    .HasColumnName("link_notes")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.LinkOwner)
                    .HasColumnName("link_owner")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LinkRating).HasColumnName("link_rating");

                entity.Property(e => e.LinkRel)
                    .IsRequired()
                    .HasColumnName("link_rel")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkRss)
                    .IsRequired()
                    .HasColumnName("link_rss")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkTarget)
                    .IsRequired()
                    .HasColumnName("link_target")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkUpdated)
                    .HasColumnName("link_updated")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.LinkUrl)
                    .IsRequired()
                    .HasColumnName("link_url")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkVisible)
                    .IsRequired()
                    .HasColumnName("link_visible")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'Y'");
            });

            modelBuilder.Entity<WpOptions>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_options");

                entity.HasIndex(e => e.OptionName)
                    .HasName("option_name")
                    .IsUnique();

                entity.Property(e => e.OptionId)
                    .HasColumnName("option_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Autoload)
                    .IsRequired()
                    .HasColumnName("autoload")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'yes'");

                entity.Property(e => e.OptionName)
                    .HasColumnName("option_name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.OptionValue)
                    .IsRequired()
                    .HasColumnName("option_value")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpPostmeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_postmeta");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.HasIndex(e => e.PostId)
                    .HasName("post_id");

                entity.Property(e => e.MetaId)
                    .HasColumnName("meta_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpPosts>(entity =>
            {
                entity.ToTable("wp_posts");

                entity.HasIndex(e => e.PostAuthor)
                    .HasName("post_author");

                entity.HasIndex(e => e.PostName)
                    .HasName("post_name");

                entity.HasIndex(e => e.PostParent)
                    .HasName("post_parent");

                entity.HasIndex(e => new { e.PostType, e.PostStatus, e.PostDate, e.Id })
                    .HasName("type_status_date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CommentCount).HasColumnName("comment_count");

                entity.Property(e => e.CommentStatus)
                    .IsRequired()
                    .HasColumnName("comment_status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'open'");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("guid")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MenuOrder).HasColumnName("menu_order");

                entity.Property(e => e.PingStatus)
                    .IsRequired()
                    .HasColumnName("ping_status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'open'");

                entity.Property(e => e.Pinged)
                    .IsRequired()
                    .HasColumnName("pinged");

                entity.Property(e => e.PostAuthor)
                    .HasColumnName("post_author")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.PostContent)
                    .IsRequired()
                    .HasColumnName("post_content")
                    .HasColumnType("longtext");

                entity.Property(e => e.PostContentFiltered)
                    .IsRequired()
                    .HasColumnName("post_content_filtered")
                    .HasColumnType("longtext");

                entity.Property(e => e.PostDate)
                    .HasColumnName("post_date")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PostDateGmt)
                    .HasColumnName("post_date_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");
                    

                entity.Property(e => e.PostExcerpt)
                    .IsRequired()
                    .HasColumnName("post_excerpt");

                entity.Property(e => e.PostMimeType)
                    .IsRequired()
                    .HasColumnName("post_mime_type")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostModified)
                    .HasColumnName("post_modified")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PostModifiedGmt)
                    .HasColumnName("post_modified_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("post_name")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostParent)
                    .HasColumnName("post_parent")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.PostPassword)
                    .IsRequired()
                    .HasColumnName("post_password")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostStatus)
                    .IsRequired()
                    .HasColumnName("post_status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'publish'");

                entity.Property(e => e.PostTitle)
                    .IsRequired()
                    .HasColumnName("post_title");

                entity.Property(e => e.PostType)
                    .IsRequired()
                    .HasColumnName("post_type")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'post'");

                entity.Property(e => e.ToPing)
                    .IsRequired()
                    .HasColumnName("to_ping");
            });

            modelBuilder.Entity<WpRedirection404>(entity =>
            {
                entity.ToTable("wp_redirection_404");

                entity.HasIndex(e => e.Created)
                    .HasName("created");

                entity.HasIndex(e => e.Ip)
                    .HasName("ip");

                entity.HasIndex(e => e.Referrer)
                    .HasName("referrer");

                entity.HasIndex(e => e.Url)
                    .HasName("url");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Agent)
                    .HasColumnName("agent")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Referrer)
                    .HasColumnName("referrer")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpRedirectionGroups>(entity =>
            {
                entity.ToTable("wp_redirection_groups");

                entity.HasIndex(e => e.ModuleId)
                    .HasName("module_id");

                entity.HasIndex(e => e.Status)
                    .HasName("status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("module_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('enabled','disabled')")
                    .HasDefaultValueSql("'enabled'");

                entity.Property(e => e.Tracking)
                    .HasColumnName("tracking")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<WpRedirectionItems>(entity =>
            {
                entity.ToTable("wp_redirection_items");

                entity.HasIndex(e => e.GroupId)
                    .HasName("group");

                entity.HasIndex(e => e.MatchUrl)
                    .HasName("match_url");

                entity.HasIndex(e => e.Regex)
                    .HasName("regex");

                entity.HasIndex(e => e.Status)
                    .HasName("status");

                entity.HasIndex(e => e.Url)
                    .HasName("url");

                entity.HasIndex(e => new { e.GroupId, e.Position })
                    .HasName("group_idpos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.ActionCode)
                    .HasColumnName("action_code")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.ActionData)
                    .HasColumnName("action_data")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.ActionType)
                    .IsRequired()
                    .HasColumnName("action_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.LastAccess).HasColumnName("last_access");

                entity.Property(e => e.LastCount)
                    .HasColumnName("last_count")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.MatchData).HasColumnName("match_data");

                entity.Property(e => e.MatchType)
                    .IsRequired()
                    .HasColumnName("match_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MatchUrl)
                    .HasColumnName("match_url")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Regex)
                    .HasColumnName("regex")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('enabled','disabled')")
                    .HasDefaultValueSql("'enabled'");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("mediumtext");
            });

            modelBuilder.Entity<WpRedirectionLogs>(entity =>
            {
                entity.ToTable("wp_redirection_logs");

                entity.HasIndex(e => e.Created)
                    .HasName("created");

                entity.HasIndex(e => e.GroupId)
                    .HasName("group_id");

                entity.HasIndex(e => e.Ip)
                    .HasName("ip");

                entity.HasIndex(e => e.ModuleId)
                    .HasName("module_id");

                entity.HasIndex(e => e.RedirectionId)
                    .HasName("redirection_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Agent)
                    .IsRequired()
                    .HasColumnName("agent")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.GroupId)
                    .HasColumnName("group_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId)
                    .HasColumnName("module_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.RedirectionId)
                    .HasColumnName("redirection_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Referrer)
                    .HasColumnName("referrer")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.SentTo)
                    .HasColumnName("sent_to")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("mediumtext");
            });

            modelBuilder.Entity<WpRevsliderCss>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_css");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Advanced)
                    .HasColumnName("advanced")
                    .HasColumnType("longtext");

                entity.Property(e => e.Handle)
                    .IsRequired()
                    .HasColumnName("handle");

                entity.Property(e => e.Hover)
                    .HasColumnName("hover")
                    .HasColumnType("longtext");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params")
                    .HasColumnType("longtext");

                entity.Property(e => e.Settings)
                    .HasColumnName("settings")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpRevsliderCssBkp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_css_bkp");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Advanced)
                    .HasColumnName("advanced")
                    .HasColumnType("longtext");

                entity.Property(e => e.Handle)
                    .IsRequired()
                    .HasColumnName("handle");

                entity.Property(e => e.Hover)
                    .HasColumnName("hover")
                    .HasColumnType("longtext");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params")
                    .HasColumnType("longtext");

                entity.Property(e => e.Settings)
                    .HasColumnName("settings")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpRevsliderLayerAnimations>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_layer_animations");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Handle)
                    .IsRequired()
                    .HasColumnName("handle");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params");

                entity.Property(e => e.Settings).HasColumnName("settings");
            });

            modelBuilder.Entity<WpRevsliderLayerAnimationsBkp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_layer_animations_bkp");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Handle)
                    .IsRequired()
                    .HasColumnName("handle");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params");

                entity.Property(e => e.Settings).HasColumnName("settings");
            });

            modelBuilder.Entity<WpRevsliderNavigations>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_navigations");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Css)
                    .IsRequired()
                    .HasColumnName("css")
                    .HasColumnType("longtext");

                entity.Property(e => e.Handle)
                    .IsRequired()
                    .HasColumnName("handle")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Markup)
                    .IsRequired()
                    .HasColumnName("markup")
                    .HasColumnType("longtext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Settings)
                    .HasColumnName("settings")
                    .HasColumnType("longtext");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(191)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpRevsliderNavigationsBkp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_navigations_bkp");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Css)
                    .IsRequired()
                    .HasColumnName("css")
                    .HasColumnType("longtext");

                entity.Property(e => e.Handle)
                    .IsRequired()
                    .HasColumnName("handle")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Markup)
                    .IsRequired()
                    .HasColumnName("markup")
                    .HasColumnType("longtext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Settings)
                    .HasColumnName("settings")
                    .HasColumnType("longtext");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(191)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpRevsliderSliders>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_sliders");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params")
                    .HasColumnType("longtext");

                entity.Property(e => e.Settings).HasColumnName("settings");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpRevsliderSlidersBkp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_sliders_bkp");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params")
                    .HasColumnType("longtext");

                entity.Property(e => e.Settings).HasColumnName("settings");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpRevsliderSlides>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_slides");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Layers)
                    .IsRequired()
                    .HasColumnName("layers")
                    .HasColumnType("longtext");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params")
                    .HasColumnType("longtext");

                entity.Property(e => e.Settings)
                    .IsRequired()
                    .HasColumnName("settings");

                entity.Property(e => e.SlideOrder).HasColumnName("slide_order");

                entity.Property(e => e.SliderId).HasColumnName("slider_id");
            });

            modelBuilder.Entity<WpRevsliderSlidesBkp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_slides_bkp");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Layers)
                    .IsRequired()
                    .HasColumnName("layers")
                    .HasColumnType("longtext");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params")
                    .HasColumnType("longtext");

                entity.Property(e => e.Settings)
                    .IsRequired()
                    .HasColumnName("settings");

                entity.Property(e => e.SlideOrder).HasColumnName("slide_order");

                entity.Property(e => e.SliderId).HasColumnName("slider_id");
            });

            modelBuilder.Entity<WpRevsliderStaticSlides>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_static_slides");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Layers)
                    .IsRequired()
                    .HasColumnName("layers")
                    .HasColumnType("longtext");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params")
                    .HasColumnType("longtext");

                entity.Property(e => e.Settings)
                    .IsRequired()
                    .HasColumnName("settings");

                entity.Property(e => e.SliderId).HasColumnName("slider_id");
            });

            modelBuilder.Entity<WpRevsliderStaticSlidesBkp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_revslider_static_slides_bkp");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Layers)
                    .IsRequired()
                    .HasColumnName("layers")
                    .HasColumnType("longtext");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params")
                    .HasColumnType("longtext");

                entity.Property(e => e.Settings)
                    .IsRequired()
                    .HasColumnName("settings");

                entity.Property(e => e.SliderId).HasColumnName("slider_id");
            });

            modelBuilder.Entity<WpTermRelationships>(entity =>
            {
                entity.HasKey(e => new { e.ObjectId, e.TermTaxonomyId })
                    .HasName("PRIMARY");

                entity.ToTable("wp_term_relationships");

                entity.HasIndex(e => e.TermTaxonomyId)
                    .HasName("term_taxonomy_id");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("object_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.TermTaxonomyId)
                    .HasColumnName("term_taxonomy_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.TermOrder).HasColumnName("term_order");
            });

            modelBuilder.Entity<WpTermTaxonomy>(entity =>
            {
                entity.HasKey(e => e.TermTaxonomyId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_term_taxonomy");

                entity.HasIndex(e => e.Taxonomy)
                    .HasName("taxonomy");

                entity.HasIndex(e => new { e.TermId, e.Taxonomy })
                    .HasName("term_id_taxonomy")
                    .IsUnique();

                entity.Property(e => e.TermTaxonomyId)
                    .HasColumnName("term_taxonomy_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.Parent)
                    .HasColumnName("parent")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Taxonomy)
                    .IsRequired()
                    .HasColumnName("taxonomy")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpTermmeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_termmeta");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.HasIndex(e => e.TermId)
                    .HasName("term_id");

                entity.Property(e => e.MetaId)
                    .HasColumnName("meta_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpTerms>(entity =>
            {
                entity.HasKey(e => e.TermId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_terms");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.HasIndex(e => e.Slug)
                    .HasName("slug");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TermGroup).HasColumnName("term_group");
            });

            modelBuilder.Entity<WpTopTen>(entity =>
            {
                entity.HasKey(e => new { e.Postnumber, e.BlogId })
                    .HasName("PRIMARY");

                entity.ToTable("wp_top_ten");

                entity.Property(e => e.Postnumber).HasColumnName("postnumber");

                entity.Property(e => e.BlogId)
                    .HasColumnName("blog_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Cntaccess).HasColumnName("cntaccess");
            });

            modelBuilder.Entity<WpTopTenDaily>(entity =>
            {
                entity.HasKey(e => new { e.Postnumber, e.DpDate, e.BlogId })
                    .HasName("PRIMARY");

                entity.ToTable("wp_top_ten_daily");

                entity.Property(e => e.Postnumber).HasColumnName("postnumber");

                entity.Property(e => e.DpDate).HasColumnName("dp_date");

                entity.Property(e => e.BlogId)
                    .HasColumnName("blog_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Cntaccess).HasColumnName("cntaccess");
            });

            modelBuilder.Entity<WpUsermeta>(entity =>
            {
                entity.HasKey(e => e.UmetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_usermeta");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.UmetaId)
                    .HasColumnName("umeta_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpUsers>(entity =>
            {
                entity.ToTable("wp_users");

                entity.HasIndex(e => e.UserEmail)
                    .HasName("user_email");

                entity.HasIndex(e => e.UserLogin)
                    .HasName("user_login_key");

                entity.HasIndex(e => e.UserNicename)
                    .HasName("user_nicename");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("display_name")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserActivationKey)
                    .IsRequired()
                    .HasColumnName("user_activation_key")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnName("user_login")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserNicename)
                    .IsRequired()
                    .HasColumnName("user_nicename")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .HasColumnName("user_pass")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserRegistered)
                    .HasColumnName("user_registered")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.UserStatus).HasColumnName("user_status");

                entity.Property(e => e.UserUrl)
                    .IsRequired()
                    .HasColumnName("user_url")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpWfblockediplog>(entity =>
            {
                entity.HasKey(e => new { e.Ip, e.Unixday, e.BlockType })
                    .HasName("PRIMARY");

                entity.ToTable("wp_wfblockediplog");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasColumnType("binary(16)")
                    .HasDefaultValueSql("'0x'");

                entity.Property(e => e.Unixday)
                    .HasColumnName("unixday")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.BlockType)
                    .HasColumnName("blockType")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'generic'");

                entity.Property(e => e.BlockCount)
                    .HasColumnName("blockCount")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpWfblocks7>(entity =>
            {
                entity.ToTable("wp_wfblocks7");

                entity.HasIndex(e => e.Expiration)
                    .HasName("expiration");

                entity.HasIndex(e => e.Ip)
                    .HasName("IP");

                entity.HasIndex(e => e.Type)
                    .HasName("type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.BlockedHits)
                    .HasColumnName("blockedHits")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BlockedTime).HasColumnName("blockedTime");

                entity.Property(e => e.Expiration)
                    .HasColumnName("expiration")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasColumnType("binary(16)")
                    .HasDefaultValueSql("'0x'");

                entity.Property(e => e.LastAttempt)
                    .HasColumnName("lastAttempt")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Parameters).HasColumnName("parameters");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<WpWfconfig>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wfconfig");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Autoload)
                    .IsRequired()
                    .HasColumnName("autoload")
                    .HasColumnType("enum('no','yes')")
                    .HasDefaultValueSql("'yes'");

                entity.Property(e => e.Val)
                    .HasColumnName("val")
                    .HasColumnType("longblob");
            });

            modelBuilder.Entity<WpWfcrawlers>(entity =>
            {
                entity.HasKey(e => new { e.Ip, e.PatternSig })
                    .HasName("PRIMARY");

                entity.ToTable("wp_wfcrawlers");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasColumnType("binary(16)")
                    .HasDefaultValueSql("'0x'");

                entity.Property(e => e.PatternSig)
                    .HasColumnName("patternSig")
                    .HasColumnType("binary(16)");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("lastUpdate")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Ptr)
                    .HasColumnName("PTR")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(8)
                    .IsFixedLength();
            });

            modelBuilder.Entity<WpWffilechanges>(entity =>
            {
                entity.HasKey(e => e.FilenameHash)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wffilechanges");

                entity.Property(e => e.FilenameHash)
                    .HasColumnName("filenameHash")
                    .HasMaxLength(64)
                    .IsFixedLength();

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasColumnName("file")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Md5)
                    .IsRequired()
                    .HasColumnName("md5")
                    .HasMaxLength(32)
                    .IsFixedLength();
            });

            modelBuilder.Entity<WpWffilemods>(entity =>
            {
                entity.HasKey(e => e.FilenameMd5)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wffilemods");

                entity.Property(e => e.FilenameMd5)
                    .HasColumnName("filenameMD5")
                    .HasColumnType("binary(16)");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IsSafeFile)
                    .IsRequired()
                    .HasColumnName("isSafeFile")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'?'");

                entity.Property(e => e.KnownFile)
                    .HasColumnName("knownFile")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.NewMd5)
                    .IsRequired()
                    .HasColumnName("newMD5")
                    .HasColumnType("binary(16)");

                entity.Property(e => e.OldMd5)
                    .IsRequired()
                    .HasColumnName("oldMD5")
                    .HasColumnType("binary(16)");

                entity.Property(e => e.Shac)
                    .IsRequired()
                    .HasColumnName("SHAC")
                    .HasColumnType("binary(32)")
                    .HasDefaultValueSql("'0x'");

                entity.Property(e => e.StoppedOnPosition)
                    .HasColumnName("stoppedOnPosition")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.StoppedOnSignature)
                    .IsRequired()
                    .HasColumnName("stoppedOnSignature")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpWfhits>(entity =>
            {
                entity.ToTable("wp_wfhits");

                entity.HasIndex(e => e.AttackLogTime)
                    .HasName("attackLogTime");

                entity.HasIndex(e => e.Ctime)
                    .HasName("k1");

                entity.HasIndex(e => new { e.Ip, e.Ctime })
                    .HasName("k2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("action")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ActionData).HasColumnName("actionData");

                entity.Property(e => e.ActionDescription).HasColumnName("actionDescription");

                entity.Property(e => e.AttackLogTime)
                    .HasColumnName("attackLogTime")
                    .HasColumnType("double(17,6) unsigned");

                entity.Property(e => e.Ctime)
                    .HasColumnName("ctime")
                    .HasColumnType("double(17,6) unsigned");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasColumnType("binary(16)");

                entity.Property(e => e.IsGoogle).HasColumnName("isGoogle");

                entity.Property(e => e.JsRun)
                    .HasColumnName("jsRun")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NewVisit)
                    .HasColumnName("newVisit")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Referer).HasColumnName("referer");

                entity.Property(e => e.StatusCode).HasColumnName("statusCode");

                entity.Property(e => e.Ua).HasColumnName("UA");

                entity.Property(e => e.Url).HasColumnName("URL");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<WpWfhoover>(entity =>
            {
                entity.ToTable("wp_wfhoover");

                entity.HasIndex(e => e.HostKey)
                    .HasName("k2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Host).HasColumnName("host");

                entity.Property(e => e.HostKey)
                    .HasColumnName("hostKey")
                    .HasMaxLength(124);

                entity.Property(e => e.Owner).HasColumnName("owner");

                entity.Property(e => e.Path).HasColumnName("path");
            });

            modelBuilder.Entity<WpWfissues>(entity =>
            {
                entity.ToTable("wp_wfissues");

                entity.HasIndex(e => e.IgnoreC)
                    .HasName("ignoreC");

                entity.HasIndex(e => e.IgnoreP)
                    .HasName("ignoreP");

                entity.HasIndex(e => e.LastUpdated)
                    .HasName("lastUpdated");

                entity.HasIndex(e => e.Status)
                    .HasName("status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IgnoreC)
                    .IsRequired()
                    .HasColumnName("ignoreC")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.IgnoreP)
                    .IsRequired()
                    .HasColumnName("ignoreP")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("lastUpdated")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.LongMsg).HasColumnName("longMsg");

                entity.Property(e => e.Severity)
                    .HasColumnName("severity")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.ShortMsg)
                    .IsRequired()
                    .HasColumnName("shortMsg")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpWfknownfilelist>(entity =>
            {
                entity.ToTable("wp_wfknownfilelist");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path");
            });

            modelBuilder.Entity<WpWflivetraffichuman>(entity =>
            {
                entity.HasKey(e => new { e.Ip, e.Identifier })
                    .HasName("PRIMARY");

                entity.ToTable("wp_wflivetraffichuman");

                entity.HasIndex(e => e.Expiration)
                    .HasName("expiration");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasColumnType("binary(16)")
                    .HasDefaultValueSql("'0x'");

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .HasColumnType("binary(32)")
                    .HasDefaultValueSql("'0x'");

                entity.Property(e => e.Expiration)
                    .HasColumnName("expiration")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<WpWflocs>(entity =>
            {
                entity.HasKey(e => e.Ip)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wflocs");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasColumnType("binary(16)")
                    .HasDefaultValueSql("'0x'");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CountryName)
                    .HasColumnName("countryName")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Ctime)
                    .HasColumnName("ctime")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Failed)
                    .HasColumnName("failed")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("float(10,7)")
                    .HasDefaultValueSql("'0.0000000'");

                entity.Property(e => e.Lon)
                    .HasColumnName("lon")
                    .HasColumnType("float(10,7)")
                    .HasDefaultValueSql("'0.0000000'");

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpWflogins>(entity =>
            {
                entity.ToTable("wp_wflogins");

                entity.HasIndex(e => e.HitId)
                    .HasName("hitID");

                entity.HasIndex(e => new { e.Ip, e.Fail })
                    .HasName("k1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("action")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ctime)
                    .HasColumnName("ctime")
                    .HasColumnType("double(17,6) unsigned");

                entity.Property(e => e.Fail)
                    .HasColumnName("fail")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.HitId).HasColumnName("hitID");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasColumnType("binary(16)");

                entity.Property(e => e.Ua).HasColumnName("UA");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpWfls2faSecrets>(entity =>
            {
                entity.ToTable("wp_wfls_2fa_secrets");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Ctime)
                    .HasColumnName("ctime")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Mode)
                    .IsRequired()
                    .HasColumnName("mode")
                    .HasColumnType("enum('authenticator')")
                    .HasDefaultValueSql("'authenticator'");

                entity.Property(e => e.Recovery)
                    .IsRequired()
                    .HasColumnName("recovery")
                    .HasColumnType("blob");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnName("secret")
                    .HasColumnType("tinyblob");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Vtime)
                    .HasColumnName("vtime")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<WpWflsSettings>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wfls_settings");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Autoload)
                    .IsRequired()
                    .HasColumnName("autoload")
                    .HasColumnType("enum('no','yes')")
                    .HasDefaultValueSql("'yes'");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("longblob");
            });

            modelBuilder.Entity<WpWfnotifications>(entity =>
            {
                entity.ToTable("wp_wfnotifications");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ctime)
                    .HasColumnName("ctime")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Html)
                    .IsRequired()
                    .HasColumnName("html");

                entity.Property(e => e.Links)
                    .IsRequired()
                    .HasColumnName("links");

                entity.Property(e => e.New)
                    .HasColumnName("new")
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasDefaultValueSql("'1000'");
            });

            modelBuilder.Entity<WpWfpendingissues>(entity =>
            {
                entity.ToTable("wp_wfpendingissues");

                entity.HasIndex(e => e.IgnoreC)
                    .HasName("ignoreC");

                entity.HasIndex(e => e.IgnoreP)
                    .HasName("ignoreP");

                entity.HasIndex(e => e.LastUpdated)
                    .HasName("lastUpdated");

                entity.HasIndex(e => e.Status)
                    .HasName("status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IgnoreC)
                    .IsRequired()
                    .HasColumnName("ignoreC")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.IgnoreP)
                    .IsRequired()
                    .HasColumnName("ignoreP")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("lastUpdated")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.LongMsg).HasColumnName("longMsg");

                entity.Property(e => e.Severity)
                    .HasColumnName("severity")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.ShortMsg)
                    .IsRequired()
                    .HasColumnName("shortMsg")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpWfreversecache>(entity =>
            {
                entity.HasKey(e => e.Ip)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wfreversecache");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasColumnType("binary(16)")
                    .HasDefaultValueSql("'0x'");

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasColumnName("host")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("lastUpdate")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<WpWfsnipcache>(entity =>
            {
                entity.ToTable("wp_wfsnipcache");

                entity.HasIndex(e => e.Expiration)
                    .HasName("expiration");

                entity.HasIndex(e => e.Ip)
                    .HasName("IP");

                entity.HasIndex(e => e.Type)
                    .HasName("type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Expiration)
                    .HasColumnName("expiration")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<WpWfstatus>(entity =>
            {
                entity.ToTable("wp_wfstatus");

                entity.HasIndex(e => e.Ctime)
                    .HasName("k1");

                entity.HasIndex(e => e.Type)
                    .HasName("k2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Ctime)
                    .HasColumnName("ctime")
                    .HasColumnType("double(17,6) unsigned");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.Msg)
                    .IsRequired()
                    .HasColumnName("msg")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(5)
                    .IsFixedLength();
            });

            modelBuilder.Entity<WpWftrafficrates>(entity =>
            {
                entity.HasKey(e => new { e.EMin, e.Ip, e.HitType })
                    .HasName("PRIMARY");

                entity.ToTable("wp_wftrafficrates");

                entity.Property(e => e.EMin)
                    .HasColumnName("eMin")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasColumnType("binary(16)")
                    .HasDefaultValueSql("'0x'");

                entity.Property(e => e.HitType)
                    .HasColumnName("hitType")
                    .HasColumnType("enum('hit','404')")
                    .HasDefaultValueSql("'hit'");

                entity.Property(e => e.Hits)
                    .HasColumnName("hits")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<WpWpeditorSettings>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wpeditor_settings");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");
            });

            modelBuilder.Entity<WpXyzIhsShortCode>(entity =>
            {
                entity.ToTable("wp_xyz_ihs_short_code");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("longtext");

                entity.Property(e => e.ShortCode)
                    .IsRequired()
                    .HasColumnName("short_code")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpYoastSeoLinks>(entity =>
            {
                entity.ToTable("wp_yoast_seo_links");

                entity.HasIndex(e => new { e.PostId, e.Type })
                    .HasName("link_direction");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.TargetPostId)
                    .HasColumnName("target_post_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpYoastSeoMeta>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_yoast_seo_meta");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("object_id")
                    .IsUnique();

                entity.Property(e => e.IncomingLinkCount)
                    .HasColumnName("incoming_link_count")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.InternalLinkCount)
                    .HasColumnName("internal_link_count")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("object_id")
                    .HasColumnType("bigint unsigned");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
