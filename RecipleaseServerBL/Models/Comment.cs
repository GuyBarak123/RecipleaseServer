using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RecipleaseServerBL.Models
{
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        [Column("CommentID")]
        public int CommentId { get; set; }
        [Required]
        [StringLength(1500)]
        public string Content { get; set; }
        [Column("RecipeID")]
        public int? RecipeId { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(RecipeId))]
        [InverseProperty("Comments")]
        public virtual Recipe Recipe { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Comments")]
        public virtual User User { get; set; }
    }
}
