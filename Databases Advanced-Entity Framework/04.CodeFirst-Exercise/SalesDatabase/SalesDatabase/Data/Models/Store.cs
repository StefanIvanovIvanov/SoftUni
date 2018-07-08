using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SalesDatabase.Data.Models;

namespace SalesDatabase.Data.Models
{
    public class Store
    {
        public Store()
        {
            Sales = new List<Sale>();
        }
        public int StoreId { get; set; }

        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
