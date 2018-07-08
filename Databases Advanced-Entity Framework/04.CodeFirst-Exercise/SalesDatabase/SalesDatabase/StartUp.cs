using System;
using SalesDatabase.Data;

namespace SalesDatabase
{
    class StartUp
    {
        public static void Main()
        {
            var db = new SalesContext();
        }
    }
}
