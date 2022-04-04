using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RecipleaseServerBL.Models
{
    [Table("Gender")]
    public partial class Gender
    {
        public Gender()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Column("GenderID")]
        public int GenderId { get; set; }
        [StringLength(255)]
        public string GenderName { get; set; }

        [InverseProperty(nameof(User.Gender))]
        public virtual ICollection<User> Users { get; set; }
    }
}
