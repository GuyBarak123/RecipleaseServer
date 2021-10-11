using System;
using System.Collections.Generic;

#nullable disable

namespace RecipleaseServerBL.Models
{
    public partial class Saved
    {
        public int? RecipeId { get; set; }
        public int? UserId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
