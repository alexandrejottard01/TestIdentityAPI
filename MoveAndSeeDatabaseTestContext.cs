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
        public virtual DbSet<Description> Description { get; set; }
        public virtual DbSet<InterestPoint> InterestPoint { get; set; }
        public virtual DbSet<UnknownPoint> UnknownPoint { get; set; }
        public virtual DbSet<User> User { get; set; }
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

                entity.Property(e => e.IdUser).HasColumnName("id_user");

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

                entity.Property(e => e.IdUser).HasColumnName("id_user");

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

                entity.Property(e => e.IdUser).HasColumnName("id_user");

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

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

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

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Pseudo)
                    .IsRequired()
                    .HasColumnName("pseudo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .HasColumnName("row_version")
                    .IsRowVersion();
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
