using System;
using System.Collections.Generic;

#nullable disable

namespace RecipleaseServerBL.Models
{
    public partial class Ingridient
    {
        public Ingridient()
        {
            RecipeIngs = new HashSet<RecipeIng>();
        }

        public int IngridientId { get; set; }
        public string IngridientName { get; set; }

        public virtual ICollection<RecipeIng> RecipeIngs { get; set; }
    }
}
