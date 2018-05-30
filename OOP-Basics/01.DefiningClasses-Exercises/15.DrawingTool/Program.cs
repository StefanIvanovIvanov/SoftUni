using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.DrawingTool
{
    public class Startup
    {
        public static void Main()
        {
            var figure = Console.ReadLine();

            if (figure.Equals("Square"))
            {
                Square.DrawSquare(int.Parse(Console.ReadLine()));
            }
            else
            {
                Rectangle.DrawRectangle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            }
        }
    }
}