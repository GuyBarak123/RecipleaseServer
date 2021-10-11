using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RecipleaseServerBL.Models
{
    public partial class RecipleaseContext : DbContext
    {
        public RecipleaseContext()
        {
        }

        public RecipleaseContext(DbContextOptions<RecipleaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Ingridient> Ingridients { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeIng> RecipeIngs { get; set; }
        public virtual DbSet<Saved> Saveds { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Reciplease;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(1500);

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Comment_RecipeID");
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Follow");

                entity.Property(e => e.FollowId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FollowID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Follow_UserID");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GenderName).HasMaxLength(255);
            });

            modelBuilder.Entity<Ingridient>(entity =>
            {
                entity.Property(e => e.IngridientId).HasColumnName("IngridientID");

                entity.Property(e => e.IngridientName).HasMaxLength(255);
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(e => e.LikesId)
                    .HasName("PK__Likes__C82065D2DD90590A");

                entity.Property(e => e.LikesId).HasColumnName("LikesID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Likes_RecipeID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Likes_UserID");
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.ToTable("Measurement");

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.MeasurementName).HasMaxLength(255);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.DateOfUpload).HasColumnType("datetime");

                entity.Property(e => e.Instructions)
                    .IsRequired()
                    .HasMaxLength(3000);

                entity.Property(e => e.RecipeDescription)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_Recipe_TagID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserID");
            });

            modelBuilder.Entity<RecipeIng>(entity =>
            {
                entity.ToTable("RecipeIng");

                entity.Property(e => e.RecipeIngId).HasColumnName("RecipeIngID");

                entity.Property(e => e.IngridientId).HasColumnName("IngridientID");

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.HasOne(d => d.Ingridient)
                    .WithMany(p => p.RecipeIngs)
                    .HasForeignKey(d => d.IngridientId)
                    .HasConstraintName("FK_IngridientID");

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.RecipeIngs)
                    .HasForeignKey(d => d.MeasurementId)
                    .HasConstraintName("FK_MeasurementID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngs)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_RecipeID");
            });

            modelBuilder.Entity<Saved>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Saved");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Recipe)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Saved_RecipeID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Saved_UserID");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.TagName).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_GenderID");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_User_TagID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
