using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RecipleaseServerBL.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            Recipes = new HashSet<Recipe>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("GenderID")]
        public int? GenderId { get; set; }
        [Column("TagID")]
        public int? TagId { get; set; }
        public bool IsAdmin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SignUpTime { get; set; }

        [ForeignKey(nameof(GenderId))]
        [InverseProperty("Users")]
        public virtual Gender Gender { get; set; }
        [ForeignKey(nameof(TagId))]
        [InverseProperty("Users")]
        public virtual Tag Tag { get; set; }
        [InverseProperty(nameof(Comment.User))]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty(nameof(Like.User))]
        public virtual ICollection<Like> Likes { get; set; }
        [InverseProperty(nameof(Recipe.User))]
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
