using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RecipleaseServerBL.Models
{
    [Table("Measurement")]
    public partial class Measurement
    {
        public Measurement()
        {
            RecipeIngs = new HashSet<RecipeIng>();
        }

        [Key]
        [Column("MeasurementID")]
        public int MeasurementId { get; set; }
        [StringLength(255)]
        public string MeasurementName { get; set; }

        [InverseProperty(nameof(RecipeIng.Measurement))]
        public virtual ICollection<RecipeIng> RecipeIngs { get; set; }
    }
}
