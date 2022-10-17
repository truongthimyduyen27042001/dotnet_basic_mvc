using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectManager.Models;
namespace ProjectManager.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
         
        [MaxLength(256)]
        public string Slug { get; set; }
        public double Price { get; set; }
        public int? Quantity { get; set; }
        
       public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
