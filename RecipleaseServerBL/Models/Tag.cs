using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RecipleaseServerBL.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Recipes = new HashSet<Recipe>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("TagID")]
        public int TagId { get; set; }
        [StringLength(255)]
        public string TagName { get; set; }

        [InverseProperty(nameof(Recipe.Tag))]
        public virtual ICollection<Recipe> Recipes { get; set; }
        [InverseProperty(nameof(User.Tag))]
        public virtual ICollection<User> Users { get; set; }
    }
}
