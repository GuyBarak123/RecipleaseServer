using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipleaseServerBL.Models;

namespace RecipleaseServer.DTO
{
    public class LookupTables
    {
        public List<Gender> Genders { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Ingridient> Ingridients { get; set; }

   
    }
}
