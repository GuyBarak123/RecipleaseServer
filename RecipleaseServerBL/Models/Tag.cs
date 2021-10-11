using System;
using System.Collections.Generic;

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

        public int TagId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
