using System;
using System.Collections.Generic;

#nullable disable

namespace RecipleaseServerBL.Models
{
    public partial class RecipeIng
    {
        public int RecipeIngId { get; set; }
        public int? RecipeId { get; set; }
        public int? IngridientId { get; set; }
        public double Amount { get; set; }
        public int? MeasurementId { get; set; }

        public virtual Ingridient Ingridient { get; set; }
        public virtual Measurement Measurement { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
