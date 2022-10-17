using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;

namespace Namespace
{
    public class Goliry
    {
         public Goliry()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
 
        public string Name { get; set; }
 
        public List<Product> Products { get; set; }
    }
}