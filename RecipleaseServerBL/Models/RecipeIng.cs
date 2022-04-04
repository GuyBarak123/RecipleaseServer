using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RecipleaseServerBL.Models
{
    [Table("RecipeIng")]
    public partial class RecipeIng
    {
        [Key]
        [Column("RecipeIngID")]
        public int RecipeIngId { get; set; }
        [Column("RecipeID")]
        public int? RecipeId { get; set; }
        [Column("IngridientID")]
        public int? IngridientId { get; set; }
        public double Amount { get; set; }
        [Column("MeasurementID")]
        public int? MeasurementId { get; set; }

        [ForeignKey(nameof(IngridientId))]
        [InverseProperty("RecipeIngs")]
        public virtual Ingridient Ingridient { get; set; }
        [ForeignKey(nameof(MeasurementId))]
        [InverseProperty("RecipeIngs")]
        public virtual Measurement Measurement { get; set; }
        [ForeignKey(nameof(RecipeId))]
        [InverseProperty("RecipeIngs")]
        public virtual Recipe Recipe { get; set; }
    }
}
