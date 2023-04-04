using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_DemoDatabase_Entity.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { set; get; }

        [Required]
        [StringLength(50)]
        public string Name { set; get; }

        [StringLength(50)]
        public string Provider { set; get; }

        public void PrintInfo() { Console.WriteLine($"{ProductId} - {Name} - {Provider}"); }
    }
}
