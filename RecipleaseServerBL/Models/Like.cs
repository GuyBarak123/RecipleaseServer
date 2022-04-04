using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RecipleaseServerBL.Models
{
    public partial class Like
    {
        [Key]
        [Column("LikesID")]
        public int LikesId { get; set; }
        [Column("RecipeID")]
        public int? RecipeId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(RecipeId))]
        [InverseProperty("Likes")]
        public virtual Recipe Recipe { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Likes")]
        public virtual User User { get; set; }
    }
}
