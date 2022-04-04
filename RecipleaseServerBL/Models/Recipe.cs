using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RecipleaseServerBL.Models
{
    [Table("Recipe")]
    public partial class Recipe
    {
        public Recipe()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            RecipeIngs = new HashSet<RecipeIng>();
        }

        [Key]
        [Column("RecipeID")]
        public int RecipeId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [StringLength(1000)]
        public string RecipeDescription { get; set; }
        [Required]
        [StringLength(3000)]
        public string Instructions { get; set; }
        [Column("TagID")]
        public int? TagId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfUpload { get; set; }

        [ForeignKey(nameof(TagId))]
        [InverseProperty("Recipes")]
        public virtual Tag Tag { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Recipes")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Comment.Recipe))]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty(nameof(Like.Recipe))]
        public virtual ICollection<Like> Likes { get; set; }
        [InverseProperty(nameof(RecipeIng.Recipe))]
        public virtual ICollection<RecipeIng> RecipeIngs { get; set; }
    }
}
