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
                optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database=Reciplease; Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Comment_RecipeID");
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.Property(e => e.FollowId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Follow_UserID");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(e => e.LikesId)
                    .HasName("PK__Likes__C82065D2691751B2");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Likes_RecipeID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Likes_UserID");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.DateOfUpload).HasDefaultValueSql("(getdate())");

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
                entity.HasOne(d => d.Recipe)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Saved_RecipeID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Saved_UserID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.SignUpTime).HasDefaultValueSql("(getdate())");

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
