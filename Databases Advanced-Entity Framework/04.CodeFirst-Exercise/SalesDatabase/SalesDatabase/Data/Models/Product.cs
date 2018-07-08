using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SalesDatabase.Data.Models;

namespace SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            Sales = new List<Sale>();
        }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }
        
        public string Description { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
