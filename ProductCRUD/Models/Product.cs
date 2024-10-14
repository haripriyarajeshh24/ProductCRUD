using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductCRUD.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [DisplayName("Prodcut Name")]
        public string ProductName { get; set; }
        public string Category { get; set; }
    }
}