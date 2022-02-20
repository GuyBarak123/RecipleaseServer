﻿using System;
using System.Collections.Generic;

#nullable disable

namespace RecipleaseServerBL.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            RecipeIngs = new HashSet<RecipeIng>();
        }

        public int RecipeId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string RecipeDescription { get; set; }
        public string Instructions { get; set; }
  
        public int? TagId { get; set; }
        public DateTime? DateOfUpload { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<RecipeIng> RecipeIngs { get; set; }
    }
}
