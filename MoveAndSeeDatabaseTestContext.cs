using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestIdentityAPI
{
    public partial class MoveAndSeeDatabaseTestContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<ApplicationUser>
    {
        public MoveAndSeeDatabaseTestContext(DbContextOptions<MoveAndSeeDatabaseTestContext> options) : base(options)
        {

        }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Description> Description { get; set; }
        public virtual DbSet<InterestPoint> InterestPoint { get; set; }
        public virtual DbSet<UnknownPoint> UnknownPoint { get; set; }
        public virtual DbSet<VoteDescription> VoteDescription { get; set; }
        public virtual DbSet<VoteInterestPoint> VoteInterestPoint { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=tcp:moveandseeservertest.database.windows.net;Database=MoveAndSeeDatabaseTest;User Id=user20172018mas;Password=Mas20172018;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.IsCertified).HasColumnName("is_certified");

                entity.Property(e => e.IsMale).HasColumnName("isMale");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasColumnName("language")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NameCertified)
                    .HasColumnName("name_certified")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .HasColumnName("row_version")
                    .IsRowVersion();

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Description>(entity =>
            {
                entity.HasKey(e => e.IdDescription);

                entity.Property(e => e.IdDescription).HasColumnName("id_description");

                entity.Property(e => e.Explication)
                    .IsRequired()
                    .HasColumnName("explication")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdInterestPoint).HasColumnName("id_interest_point");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("id_user")
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdInterestPointNavigation)
                    .WithMany(p => p.Description)
                    .HasForeignKey(d => d.IdInterestPoint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subject");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Description)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_writing");
            });

            modelBuilder.Entity<InterestPoint>(entity =>
            {
                entity.HasKey(e => e.IdInterestPoint);

                entity.ToTable("Interest_point");

                entity.Property(e => e.IdInterestPoint).HasColumnName("id_interest_point");

                entity.Property(e => e.DateCreation)
                    .HasColumnName("date_creation")
                    .HasColumnType("date");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("id_user")
                    .HasMaxLength(450);

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.InterestPoint)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_creator_interest_point");
            });

            modelBuilder.Entity<UnknownPoint>(entity =>
            {
                entity.HasKey(e => e.IdUnknownPoint);

                entity.ToTable("Unknown_point");

                entity.Property(e => e.IdUnknownPoint).HasColumnName("id_unknown_point");

                entity.Property(e => e.DateCreation)
                    .HasColumnName("date_creation")
                    .HasColumnType("date");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("id_user")
                    .HasMaxLength(450);

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(9, 6)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UnknownPoint)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_creator_unknown_point");
            });

            modelBuilder.Entity<VoteDescription>(entity =>
            {
                entity.HasKey(e => new { e.IdDescription, e.IdUser });

                entity.ToTable("Vote_description");

                entity.Property(e => e.IdDescription).HasColumnName("id_description");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IsPositiveAssessment).HasColumnName("is_positive_assessment");

                entity.HasOne(d => d.IdDescriptionNavigation)
                    .WithMany(p => p.VoteDescription)
                    .HasForeignKey(d => d.IdDescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_description_voted");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.VoteDescription)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_voter_description");
            });

            modelBuilder.Entity<VoteInterestPoint>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdInterestPoint });

                entity.ToTable("Vote_interest_point");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IdInterestPoint).HasColumnName("id_interest_point");

                entity.Property(e => e.IsPositiveAssessment).HasColumnName("is_positive_assessment");

                entity.HasOne(d => d.IdInterestPointNavigation)
                    .WithMany(p => p.VoteInterestPoint)
                    .HasForeignKey(d => d.IdInterestPoint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_interest_point_voted");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.VoteInterestPoint)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vote_interest_point");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
