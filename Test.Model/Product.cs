using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ? ProductName { get; set; }
        [Required]
        public string ? Description { get; set; }
        [Required]
        public int  Price { get; set; }
        [Required]
        public int Quentity { get; set; }
        public string ? ProductImg { get; set; }
      
        public int  CatagoryId { get; set;}
        public Catagory? CatagoryName { get; set; }
    }
}
