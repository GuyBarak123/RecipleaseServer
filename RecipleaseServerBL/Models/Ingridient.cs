using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RecipleaseServerBL.Models
{
    public partial class Ingridient
    {
        public Ingridient()
        {
            RecipeIngs = new HashSet<RecipeIng>();
        }

        [Key]
        [Column("IngridientID")]
        public int IngridientId { get; set; }
        [StringLength(255)]
        public string IngridientName { get; set; }

        [InverseProperty(nameof(RecipeIng.Ingridient))]
        public virtual ICollection<RecipeIng> RecipeIngs { get; set; }
    }
}
