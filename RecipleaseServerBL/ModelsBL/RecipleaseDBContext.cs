using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RecipleaseServerBL.Models
{
    public partial class RecipleaseContext : DbContext
    {

        public User Login(string Email, string Password)
        {
            User user = this.Users
                .Where(u => u.Email == Email && u.Password == Password)
                .Include(u => u.Recipes)
                .ThenInclude(r => r.RecipeIngs)
                .FirstOrDefault();
            return user;
        }


    }
}
