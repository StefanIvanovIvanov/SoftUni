using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDatabase.Data
{
    public class Configuration
    {
        public static string ConnectionString { get; set; } =
            @"Server=.;Database=Sales;Integrated Security=True";
    }
}
