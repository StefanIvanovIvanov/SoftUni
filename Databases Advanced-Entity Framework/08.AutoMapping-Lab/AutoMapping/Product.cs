using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapping
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ProductStocks> ProductStocks = new List<ProductStocks>();
    }
}
