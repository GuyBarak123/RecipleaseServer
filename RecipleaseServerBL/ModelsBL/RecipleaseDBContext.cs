using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RecipleaseServerBL.Models
{
    public partial class RecipleaseDBContext : DbContext
    {

        public User Login(string Name, string Password)
        {
            User user = this.Users
                .Where(u => u.Name == Name && u.Password == Password).FirstOrDefault();
            return user;
        }


    }
}
