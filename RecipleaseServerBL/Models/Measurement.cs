﻿using System;
using System.Collections.Generic;

#nullable disable

namespace RecipleaseServerBL.Models
{
    public partial class Measurement
    {
        public Measurement()
        {
            RecipeIngs = new HashSet<RecipeIng>();
        }

        public int MeasurementId { get; set; }
        public string MeasurementName { get; set; }

        public virtual ICollection<RecipeIng> RecipeIngs { get; set; }
    }
}
