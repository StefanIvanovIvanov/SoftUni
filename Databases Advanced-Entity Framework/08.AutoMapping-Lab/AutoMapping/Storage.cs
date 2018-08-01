using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapping
{
    public class Storage
    {
        public int StorageId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public ICollection<ProductStocks> ProductStocks = new List<ProductStocks>();

    }
}
