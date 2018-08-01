using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AutoMapping
{
    public class ProductStocks
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}

