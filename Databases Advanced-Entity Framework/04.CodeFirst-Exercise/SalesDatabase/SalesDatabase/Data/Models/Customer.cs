using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SalesDatabase.Data.Models;

namespace SalesDatabase.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            Sales = new List<Sale>();
        }

        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
